// =============================================================================
// Catteria.Desktop - Themes/ThemeManager.cs
// =============================================================================
// Aplica o tema escuro sobre a árvore de controles, e ao voltar pro claro
// RESTAURA as cores originais de cada controle (as que vieram do Designer),
// em vez de reaplicar uma paleta clara fixa. Isso garante que qualquer
// ajuste manual de cor feito numa tela específica no Designer não se perde
// quando o usuário troca de tema.
// =============================================================================

using System.Runtime.CompilerServices;
using Catteria.Desktop.Themes;
using Guna.UI2.WinForms;

namespace Catteria.Desktop.Themes
{
    public static class ThemeManager
    {
        public static bool TemaEscuroAtual { get; private set; } = true;

        // =====================================================================
        // PALETA ESCURA (não faz parte da identidade visual — só modo alternativo)
        // =====================================================================

        private static readonly Color BgDark = Color.FromArgb(32, 32, 32);
        private static readonly Color BgDarkSecondary = Color.FromArgb(45, 45, 48);
        private static readonly Color FgDark = Color.White;
        private static readonly Color HoverDark = Color.FromArgb(65, 65, 68);
        private static readonly Color GridBordaDark = Color.FromArgb(60, 60, 60);

        // =====================================================================
        // SNAPSHOT DAS CORES ORIGINAIS
        // =====================================================================
        // ConditionalWeakTable em vez de Dictionary: não precisa remover a
        // entrada manualmente quando um Form/UserControl é fechado/descartado
        // — o GC coleta a entrada junto com o controle, sem vazar memória.

        private static readonly ConditionalWeakTable<Control, Snapshot> _originais = new();

        private class Snapshot
        {
            public Color? BackColor;
            public Color? ForeColor;
            public Color? FillColor;
            public Color? HoverFillColor;
            public Color? BorderColor;
            public int? BorderThickness;
            public bool? ShadowEnabled;
            public ToolStripRenderer Renderer;

            // Específico de DataGridView
            public Color? GridBackgroundColor;
            public BorderStyle? GridBorderStyle;
            public Color? GridColor;
            public Color? HeaderBackColor;
            public Color? HeaderForeColor;
            public Color? CellBackColor;
            public Color? CellForeColor;
            public Color? SelectionBackColor;
            public Color? AlternatingBackColor;
            public bool? EnableHeadersVisualStyles;
        }

        /// <summary>
        /// Guarda o estado atual do controle na primeira vez que ele é visitado,
        /// antes de qualquer alteração de tema. É essa cópia que volta quando o
        /// usuário retorna pro tema claro — sem depender de cores fixas.
        /// </summary>
        private static Snapshot ObterOuCapturarOriginal(Control controle)
        {
            if (_originais.TryGetValue(controle, out var existente))
                return existente;

            var snap = new Snapshot
            {
                BackColor = controle.BackColor,
                ForeColor = controle.ForeColor
            };

            switch (controle)
            {
                case Guna2Button gBtn:
                    snap.FillColor = gBtn.FillColor;
                    snap.HoverFillColor = gBtn.HoverState.FillColor;
                    snap.BorderThickness = gBtn.BorderThickness;
                    snap.ShadowEnabled = gBtn.ShadowDecoration.Enabled;
                    break;

                case Guna2Panel gPanel:
                    snap.FillColor = gPanel.FillColor;
                    snap.BorderThickness = gPanel.BorderThickness;
                    break;

                case Guna2GroupBox gGroup:
                    snap.FillColor = gGroup.FillColor;
                    snap.BorderColor = gGroup.BorderColor;
                    break;

                case DataGridView dgv:
                    snap.GridBackgroundColor = dgv.BackgroundColor;
                    snap.GridBorderStyle = dgv.BorderStyle;
                    snap.GridColor = dgv.GridColor;
                    snap.HeaderBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
                    snap.HeaderForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;
                    snap.CellBackColor = dgv.DefaultCellStyle.BackColor;
                    snap.CellForeColor = dgv.DefaultCellStyle.ForeColor;
                    snap.SelectionBackColor = dgv.DefaultCellStyle.SelectionBackColor;
                    snap.AlternatingBackColor = dgv.AlternatingRowsDefaultCellStyle.BackColor;
                    snap.EnableHeadersVisualStyles = dgv.EnableHeadersVisualStyles;
                    break;

                case ToolStrip ts:
                    snap.Renderer = ts.Renderer;
                    break;
            }

            _originais.Add(controle, snap);
            return snap;
        }

        // =====================================================================
        // APLICAÇÃO DO TEMA
        // =====================================================================

        public static void Aplicar(Control raiz, bool? escuro = null)
        {
            bool tema = escuro ?? TemaEscuroAtual;
            if (escuro.HasValue) TemaEscuroAtual = escuro.Value;

            AplicarRecursivo(raiz, tema);

            raiz.Invalidate(true);
            raiz.Update();
        }

        private static void AplicarRecursivo(Control controle, bool escuro)
        {
            var original = ObterOuCapturarOriginal(controle); // sempre captura ANTES de mexer em qualquer cor

            switch (controle)
            {
                case Guna2Button gBtn:
                    bool ehIcone = string.IsNullOrWhiteSpace(gBtn.Text); // avatar/ícone: sem texto, só imagem

                    if (escuro)
                    {
                        if (ehIcone)
                        {
                            gBtn.FillColor = BgDark;
                            gBtn.ForeColor = FgDark;
                            gBtn.HoverState.FillColor = BgDark;
                        }
                        else
                        {
                            gBtn.FillColor = BgDarkSecondary;
                            gBtn.ForeColor = FgDark;
                            gBtn.HoverState.FillColor = HoverDark;
                        }
                        gBtn.BorderThickness = 1;
                        gBtn.BorderColor = gBtn.FillColor;
                        gBtn.ShadowDecoration.Enabled = false;
                    }
                    else
                    {
                        // Reset: volta exatamente pro que estava antes de qualquer tema mexer aqui
                        gBtn.FillColor = original.FillColor!.Value;
                        gBtn.ForeColor = original.ForeColor!.Value;
                        gBtn.HoverState.FillColor = original.HoverFillColor!.Value;
                        gBtn.BorderThickness = original.BorderThickness!.Value;
                        gBtn.ShadowDecoration.Enabled = original.ShadowEnabled!.Value;
                    }
                    break;

                case DataGridView dgv:
                    if (escuro)
                    {
                        dgv.BackgroundColor = BgDark;
                        dgv.BorderStyle = BorderStyle.None;
                        dgv.GridColor = GridBordaDark;
                        dgv.ColumnHeadersDefaultCellStyle.BackColor = BgDark;
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = FgDark;
                        dgv.DefaultCellStyle.BackColor = BgDarkSecondary;
                        dgv.DefaultCellStyle.ForeColor = FgDark;
                        dgv.DefaultCellStyle.SelectionBackColor = HoverDark;
                        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(38, 38, 40);
                        dgv.EnableHeadersVisualStyles = false;
                    }
                    else
                    {
                        // Reset: restaura os valores originais em vez de chamar CatteriaTheme.AplicarEstiloGrid
                        dgv.BackgroundColor = original.GridBackgroundColor!.Value;
                        dgv.BorderStyle = original.GridBorderStyle!.Value;
                        dgv.GridColor = original.GridColor!.Value;
                        dgv.ColumnHeadersDefaultCellStyle.BackColor = original.HeaderBackColor!.Value;
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = original.HeaderForeColor!.Value;
                        dgv.DefaultCellStyle.BackColor = original.CellBackColor!.Value;
                        dgv.DefaultCellStyle.ForeColor = original.CellForeColor!.Value;
                        dgv.DefaultCellStyle.SelectionBackColor = original.SelectionBackColor!.Value;
                        dgv.AlternatingRowsDefaultCellStyle.BackColor = original.AlternatingBackColor!.Value;
                        dgv.EnableHeadersVisualStyles = original.EnableHeadersVisualStyles!.Value;
                    }
                    break;

                case ToolStrip ts:
                    ts.Renderer = escuro
                        ? new ToolStripProfessionalRenderer(new DarkColorTable())
                        : original.Renderer; // reset: volta pro renderer original, não recria um novo
                    break;

                case Guna2Panel gPanel:
                    if (escuro)
                    {
                        gPanel.FillColor = BgDarkSecondary;
                        gPanel.BorderThickness = 0;
                        gPanel.ForeColor = FgDark;
                    }
                    else
                    {
                        gPanel.FillColor = original.FillColor!.Value;
                        gPanel.BorderThickness = original.BorderThickness!.Value;
                        gPanel.ForeColor = original.ForeColor!.Value;
                    }
                    break;

                case Guna2GroupBox gGroup:
                    if (escuro)
                    {
                        gGroup.FillColor = BgDark;
                        gGroup.BorderColor = BgDarkSecondary;
                        gGroup.ForeColor = FgDark;
                    }
                    else
                    {
                        gGroup.FillColor = original.FillColor!.Value;
                        gGroup.BorderColor = original.BorderColor!.Value;
                        gGroup.ForeColor = original.ForeColor!.Value;
                    }
                    break;

                case Label:
                    controle.BackColor = escuro ? Color.Transparent : original.BackColor!.Value;
                    controle.ForeColor = escuro ? FgDark : original.ForeColor!.Value;
                    break;

                default:
                    controle.BackColor = escuro ? BgDark : original.BackColor!.Value;
                    controle.ForeColor = escuro ? FgDark : original.ForeColor!.Value;
                    break;
            }

            // Garante que qualquer controle adicionado DEPOIS deste Aplicar
            // (labels criados após carregar dados da API, telas recriadas ao
            // navegar, etc.) seja automaticamente temado com o estado atual —
            // sem precisar chamar Aplicar manualmente de novo em cada lugar.
            controle.ControlAdded -= ControleAdicionadoDepois; // evita assinar duas vezes o mesmo controle
            controle.ControlAdded += ControleAdicionadoDepois;

            foreach (Control filho in controle.Controls)
                AplicarRecursivo(filho, escuro);
        }

        private static void ControleAdicionadoDepois(object sender, ControlEventArgs e)
        {
            // Sempre usa o estado ATUAL do ThemeManager, nunca uma variável
            // local do form — é isso que evita telas nascendo com tema errado.
            AplicarRecursivo(e.Control, TemaEscuroAtual);
        }
    }

    /// <summary>Cores da barra de ferramentas/menu no tema escuro.</summary>
    public class DarkColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected => Color.FromArgb(0, 120, 215);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(45, 45, 48);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(45, 45, 48);
        public override Color ToolStripDropDownBackground => Color.FromArgb(45, 45, 48);
        public override Color ImageMarginGradientBegin => Color.FromArgb(45, 45, 48);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(45, 45, 48);
        public override Color ImageMarginGradientEnd => Color.FromArgb(45, 45, 48);
    }
}