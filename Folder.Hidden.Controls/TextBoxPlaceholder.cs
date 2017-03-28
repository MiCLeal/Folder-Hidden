using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace Folder.Hidden.Controls
{
    /// <summary>
    /// Um TextBox com Placeholder.
    /// </summary>
    public class TextBoxPlaceholder : TextBox
    {
        #region Propriedades

        string _placeholderText = DEFAULT_PLACEHOLDER;
        bool _isPlaceholderActive;

        /// <summary>
        /// Recebe um valor indicando se o Placeholder está ativo.
        /// </summary>
        [Browsable(false)]
        public bool IsPlaceholderActive
        {
            get
            {
                return _isPlaceholderActive;
            }
            private set
            {
                if (value != _isPlaceholderActive)
                {
                    _isPlaceholderActive = value;
                    OnPlaceholderActiveChanged(value);
                }
            }
        }

        /// <summary>
        /// Recebe ou estabelece o Placeholder no TextBoxPlaceholder.
        /// </summary>
        [Description("O Placeholder associados com este controle."), Category("Placeholder"), DefaultValue(DEFAULT_PLACEHOLDER)]
        public string PlaceholderText
        {
            get
            {
                return _placeholderText;
            }
            set
            {
                _placeholderText = value;

                // Somente usa o novo valor se o Placeholder estiver ativo.
                if (this.IsPlaceholderActive)
                    this.Text = value;
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get
            {
                // Check 'IsPlaceholderActive' to avoid this if-clause when the text is the same as the placeholder but actually it's not the placeholder.
                // Check 'base.Text == this.Placeholder' because in some cases IsPlaceholderActive changes too late although it isn't the placeholder anymore.
                // If you want to get the Text Property and it still contains the placeholder, an empty string will return.
                if (this.IsPlaceholderActive && base.Text == this.PlaceholderText)
                    return String.Empty;

                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// Recebe ou estabelece uma cor do foreground do controle.
        /// </summary>
        public override Color ForeColor
        {
            get
            {
                // We have to differentiate whether the system is asking for the ForeColor to draw it
                // or the developer is asking for the color.
            if (this.IsPlaceholderActive && Environment.StackTrace.Contains("System.Windows.Forms.Control.InitializeDCForWmCtlColor(IntPtr dc, Int32 msg)"))
                return Color.LightGray;

            return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// Ocorre quando o valor da Propriedade IsPlaceholderActive muda.
        /// </summary>
        [Description("Ocorre quando o valor da Propriedade IsPlaceholderActive muda.")]
        public event EventHandler<PlaceholderActiveChangedEventArgs> PlaceholderActiveChanged;

        #endregion

        #region Variáveis Globais

        /// <summary>
        /// Especifica o texto padrão do placeholder.
        /// </summary>
        const string DEFAULT_PLACEHOLDER = "<Input>";

        /// <summary>
        /// Flag to avoid the TextChanged Event. Don't access directly, use Method 'ActionWithoutTextChanged(Action act)' instead.
        /// </summary>
        bool avoidTextChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa uma nova instância da Classe <see cref="TextBoxPlaceholder"/>.
        /// </summary>
        public TextBoxPlaceholder()
        {
            base.Text = this.PlaceholderText;

            SubscribeEvents();

            // Estabelece o padrão.
            this.IsPlaceholderActive = true;
        }

        #endregion

        #region Funções

        /// <summary>
        /// Insere Placeholder, atribui o estilo do Placeholder e estabelece o cursor na primeira posição.
        /// </summary>
        public void Reset()
        {
            this.IsPlaceholderActive = true;

            ActionWithoutTextChanged(() => this.Text = this.PlaceholderText);
            this.Select(0, 0);
        }

        /// <summary>
        /// Executa uma ação evitando o Evento TextChanged.
        /// </summary>
        /// <param name="act">Especifica a ação para ser executada.</param>
        private void ActionWithoutTextChanged(Action act)
        {
            avoidTextChanged = true;

            act.Invoke();

            avoidTextChanged = false;
        }

        /// <summary>
        /// Assina os eventos necessarios.
        /// </summary>
        private void SubscribeEvents()
        {
            this.TextChanged += TextBoxPlaceholder_TextChanged;
        }

        #endregion

        #region Eventos 
        
        private void TextBoxPlaceholder_TextChanged(object sender, EventArgs e)
        {
            // Check flag
            if (avoidTextChanged)
                return;

            // Executa o código evitando chamada recursiva.
            ActionWithoutTextChanged(delegate
            {
                // Se o Texto estiver vazio, inserir Placeholder e estabelecer cursor na primeira posição.
                if (String.IsNullOrEmpty(this.Text))
                {
                    Reset();
                    return;
                }

                // Se o Placeholder estiver ativo, reverte o estado para uma TextBox Padrão.
                if (this.IsPlaceholderActive)
                {
                    this.IsPlaceholderActive = false;

                    // Throw away the placeholder but leave the new typed char
                    this.Text = this.Text.Replace(this.PlaceholderText, String.Empty);

                    // Estabelece a seleção para a última posição.
                    this.Select(this.TextLength, 0);
                }
            });

            this.Font = this.Font;
        }


        protected override void OnGotFocus(EventArgs e)
        {
            // Without this line it would highlight the placeholder when getting focus
            this.Select(0, 0);
            base.OnGotFocus(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // When you click on the placerholderTextBox and the placerholder is active, jump to first position
            if (this.IsPlaceholderActive)
                Reset();

            base.OnMouseDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Prevents that the user can go through the placeholder with arrow keys
            if (IsPlaceholderActive && (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down))
                e.Handled = true;

            base.OnKeyDown(e);
        }

        protected virtual void OnPlaceholderActiveChanged(bool newValue)
        {
            if (PlaceholderActiveChanged != null)
                PlaceholderActiveChanged(this, new PlaceholderActiveChangedEventArgs(newValue));
        }

        #endregion
    }

    /// <summary>
    /// Prove dados para o Evento PlaceholderActiveChanged.
    /// </summary>
    public class PlaceholderActiveChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Inicializa uma nova instância da Classe <see cref="PlaceholderActiveChangedEventArgs"/>.
        /// </summary>
        /// <param name="newValue">O novo valor para a Propriedade IsPlaceholderActive.</param>
        public PlaceholderActiveChangedEventArgs(bool newValue)
        {
            this.NewValue = newValue;
        }

        /// <summary>
        /// Recebe o novo valor para a propriedade IsPlaceholderActive.
        /// </summary>
        public bool NewValue { get; private set; }
    }
}
