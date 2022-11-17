using FactoryForm.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ClearInputs()
        {
            TitleTextBox.Text = String.Empty;
            CountOfWorkshopsTextBox.Text = String.Empty;
            CountOfEmployeeTextBox.Text = String.Empty;
            CountOfMasterTextBox.Text = String.Empty;
            EmployeeSalaryTextBox.Text = String.Empty;
            MasterSalaryTextBox.Text = String.Empty;
            ProfitFromEmployeeTextBox.Text = String.Empty;
            ProfitFromMasterTextBox.Text = String.Empty;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            var factory = new Factory(TitleTextBox.Text, 
                int.Parse(CountOfWorkshopsTextBox.Text),
                int.Parse(CountOfEmployeeTextBox.Text),
                int.Parse(CountOfMasterTextBox.Text),
                int.Parse(EmployeeSalaryTextBox.Text),
                int.Parse(MasterSalaryTextBox.Text), 
                int.Parse(ProfitFromEmployeeTextBox.Text),
                int.Parse(ProfitFromMasterTextBox.Text));

            var listViewFactory = new ListViewItem(factory.Title);
            listViewFactory.Tag = factory;

            factoriesListView.Items.Add(listViewFactory);

            ClearInputs();
        }

        private void factoriesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (factoriesListView.SelectedItems.Count > 0)
            {
                var factory = (Factory)factoriesListView.SelectedItems[0].Tag;

                if (factory != null)
                {
                    TitleTextBox.Text               = factory.Title;
                    CountOfWorkshopsTextBox.Text    = factory.CountOfWorkshop.ToString();
                    CountOfEmployeeTextBox.Text     = factory.CountOfEmployee.ToString();
                    CountOfMasterTextBox.Text       = factory.CountOfMasters.ToString();
                    EmployeeSalaryTextBox.Text      = factory.EmployeeSalary.ToString();
                    MasterSalaryTextBox.Text        = factory.MasterSalary.ToString();
                    ProfitFromEmployeeTextBox.Text  = factory.EmployeeSalary.ToString();
                    ProfitFromMasterTextBox.Text    = factory.ProfitFromMaster.ToString();
                }
            }
            else
            {
                ClearInputs();
            }
        }

        private async void Load_Click(object sender, EventArgs e)
        {
            List<Factory> factories = await DeserializeAsync();

            foreach (Factory item in factories)
            {
                ListViewItem lvi = new ListViewItem(item.Title);
                lvi.Tag = item;

                factoriesListView.Items.Add(lvi);
            }
        }
        private async Task<List<Factory>> DeserializeAsync()
        {
            using (FileStream stream = new FileStream("FactoriesData.json", FileMode.OpenOrCreate))
            {
                List<Factory> factories = await JsonSerializer.DeserializeAsync<List<Factory>>(stream);

                return factories;
            }
        }

        private async void Unload_Click(object sender, EventArgs e)
        {
            var factories = new List<Factory>();

            foreach (ListViewItem item in factoriesListView.Items)
            {
                if (item != null)
                    factories.Add((Factory)item.Tag);
            }

            await SerializeAsync(factories);
        }
        private async Task SerializeAsync(List<Factory> factories)
        {
            using (var stream = new FileStream("FactoriesData.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<Factory>>(stream, factories);
            }
        }
    }
}