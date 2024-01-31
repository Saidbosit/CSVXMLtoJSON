using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Text;

namespace Test2
{
    public partial class MainForm : Form
    {
        private List<string> processedCsvFiles;
        private List<string> processedXmlFiles;
        private List<UserData> userDataList;
        public string countGenerateCountUser = "0";

        public MainForm()
        {
            InitializeComponent();
            processedCsvFiles = new List<string>();
            processedXmlFiles = new List<string>();
            userDataList = new List<UserData>();
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void ProcessCsvFile(string filePath)
        {

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1))
            {
                var data = line.Split(';');
                var userData = new UserData
                {
                    UserId = data[0],
                    FirstName = data[1],
                    LastName = data[2],
                    Phone = data[3]
                };
                userDataList.Add(userData);
            }

            processedCsvFiles.Add(filePath);
            GenerateLabelReport();
        }

        private void ProcessXmlFile(string filePath)
        {
            XElement xml = XElement.Load(filePath);
            foreach (var card in xml.Elements("Card"))
            {
                var userData = new UserData
                {
                    UserId = card.Attribute("UserId").Value,
                    Pan = card.Element("Pan").Value,
                    ExpDate = card.Element("ExpDate").Value
                };
                userDataList.Add(userData);
            }

            processedXmlFiles.Add(filePath);
            GenerateLabelReport();
        }

        private void GenerateLabelReport()
        {
            if (processedCsvFiles.Count > 0 && processedXmlFiles.Count > 0)
            {
                var countUser = userDataList.GroupBy(user => user.UserId)
                                                                         .Where(group => group.Count() > 1)
                                                                         .Count();
                Count.Text = countUser.ToString();
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            {
                if (processedCsvFiles.Count > 0 && processedXmlFiles.Count > 0)
                {
                    var combinedUserDataList = new List<UserData>();


                    var groupedData = userDataList.GroupBy(user => user.UserId);

                    foreach (var group in groupedData)
                    {
                        if (group.Count() < 2) continue;
                        var userData = new UserData
                        {
                            UserId = group.Key,
                            FirstName = group.Where(a => a.FirstName != null).Select(user => user.FirstName).FirstOrDefault(),
                            LastName = group.Where(q => q.LastName != null).Select(user => user.LastName).FirstOrDefault(),
                            Phone = group.Where(w => w.Phone != null).Select(user => user.Phone).FirstOrDefault(),
                            Pan = group.Where(u => u.Pan != null).Select(user => user.Pan).FirstOrDefault(),
                            ExpDate = group.Where(u => u.ExpDate != null).Select(user => user.ExpDate).FirstOrDefault()
                        };

                        combinedUserDataList.Add(userData);
                    }
                    string json = JsonConvert.SerializeObject(new { records = combinedUserDataList });
                    
                    SaveJsonToFile(json);
                    
                    MessageBox.Show($"Записей сформирована: {combinedUserDataList.Count}");



                }
            }
        }
        private void SaveJsonToFile(string json)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputPath = saveFileDialog.FileName;
                    File.WriteAllText(outputPath, json);
                }
            }
        }


        private void AddCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName;
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read), new UTF8Encoding())) // do anything you want, e.g. read it
                {
                    var nameArray = dialog.SafeFileName.Split('.');
                    var type = nameArray[nameArray.Length - 1];
                    switch (type)
                    {
                        case "csv": ProcessCsvFile(path); break;
                    }

                    var test = File.ReadAllLines(path);

                }
            }
}

        private void AddXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.xml;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName;
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read), new UTF8Encoding())) // do anything you want, e.g. read it
                {
                    var nameArray = dialog.SafeFileName.Split('.');
                    var type = nameArray[nameArray.Length - 1];
                    switch (type)
                    {
                        case "xml": ProcessXmlFile(path); break;
                    }

                    var test = File.ReadAllLines(path);

                }
            }
            
        }

        public class UserData
        {
            public string UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
            public string Pan { get; set; }
            public string ExpDate { get; set; }
        }

    }
}
