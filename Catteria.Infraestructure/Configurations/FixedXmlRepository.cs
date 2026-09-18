using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace Catteria.Infraestructure.Configurations;

/// <summary>
/// Repositório de chaves do Data Protection que lê uma chave FIXA
/// vinda de configuração (Application Setting), em vez de um storage
/// compartilhado. Usado para permitir que Catteria.UI e Catteria.API,
/// hospedados em App Services separados, validem o mesmo cookie de
/// autenticação sem precisar de uma Storage Account.
/// </summary>
public class FixedXmlRepository : IXmlRepository
{
    private readonly XElement? _element;

    public FixedXmlRepository(string? base64Xml)
    {
        if (!string.IsNullOrWhiteSpace(base64Xml))
        {
            var xml = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64Xml));
            _element = XElement.Parse(xml);
        }
    }

    public IReadOnlyCollection<XElement> GetAllElements()
        => _element is null
            ? Array.Empty<XElement>()
            : new List<XElement> { _element };

    public void StoreElement(XElement element, string friendlyName)
    {
        // Intencionalmente vazio: a chave é fixa e definida via configuração,
        // não geramos/gravamos novas chaves em tempo de execução.
    }
}