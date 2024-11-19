using System;
using FormsLibrary;

namespace OblivionCharacterManager
{
    /// <summary>
    /// Displays information to a user about an error.
    /// </summary>
    public partial class ErrorForm : BaseErrorForm
    {
        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.ErrorForm"/> instance.
        /// </summary>
        public ErrorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialises a new <see cref="OblivionCharacterManager.ErrorForm"/> instance.
        /// </summary>
        /// <param name="exception">The exception whose information to display on the form.</param>
        public ErrorForm(Exception exception)
            : base(exception)
        {
            InitializeComponent();
        }
    }
}