using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace gdiplusShowcase
{
    public partial class FrmMain : Form
    {
        static List<Type> allForms = new List<Type>();
        public FrmMain()
        {
          
            InitializeComponent();

            allForms = GetAllFormsInsideProject();
            
            lbxChooseForm.DataSource = allForms;
            lbxChooseForm.DisplayMember = "Name"; //Verhindert dass der Namespace in Liste ausgegeben wird.
            
            
        }

        /// <summary>
        /// Lädt alle Form-Dateien des Projekts.
        /// </summary>
        /// <see cref="https://kellyschronicles.wordpress.com/2011/08/06/show-all-forms-in-a-project-with-c/"/>
        private List<Type> GetAllFormsInsideProject()
        {
            List<Type> types = new List<Type>();

            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetEntryAssembly();

            Type[] Types = myAssembly.GetTypes();

            foreach (Type myType in Types)

            {
                if (myType.BaseType == null)
                {
                    continue;
                }

                if (myType.BaseType.FullName == "System.Windows.Forms.Form")
                {
                    if(myType.Name != this.Name)
                    {
                        types.Add(myType);
                    }
                }
            }

            return types;
        }

        /// <summary>
        /// Bringt die ausgewählte Form zur Darstellung.
        /// </summary>
        /// <see cref="https://foxlearn.com/articles/get-all-forms-and-open-form-with-form-name-in-csharp-209.html"/>
        private void btnShowForm_Click(object sender, EventArgs e)
        {
            Type t = allForms[lbxChooseForm.SelectedIndex];
           
            if (t != null)
            {
                //Create a new instance
                Form frm = Activator.CreateInstance(t) as Form;
                if (frm != null)
                {
                    frm.ShowDialog();
                }
            }
        }
    }
}
