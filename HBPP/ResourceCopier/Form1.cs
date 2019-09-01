using NExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;
using OfficeOpenXml;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace ResourceCopier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void GetFiile(OpenFileDialog dialog, System.Windows.Forms.TextBox destinationTextBox)
        {
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filePath = dialog.FileName;
                destinationTextBox.Text = filePath;
            }
        }


        private void Button_Browse_Source_Click(object sender, EventArgs e)
        {
            GetFiile(openFileDialog_Source, textBox_Source);
        }

        private void Button_Browse_Destination_Click(object sender, EventArgs e)
        {
            GetFiile(openFileDialog_Destination, textBox_Destination);
        }

        int sourceProjectIndex = 1;
        int sourceFileIndex = 2;
        int sourceKeyIndex = 3;
        int sourceEnglishIndex = 4;
        int sourceFrenchIndex = 5;

        int destinationKeyIndex = 3;
        int destinationEnglishIndex = 5;
        int destinationFrenchIndex = 7;
        int destinationFileIndex = 2;
        int destinationProjectIndex = 1;

        private void UpdateStatus(string text)
        {
            this.label_Status.Text = text;
            this.Refresh();
        }
        private void Button_Start_Click(object sender, EventArgs e)
        {
            this.UpdateStatus("loading source file...");
            var sourceResource = GetResource(textBox_Source.Text, sourceKeyIndex, sourceEnglishIndex, sourceFrenchIndex, sourceFileIndex, sourceProjectIndex);

            this.UpdateStatus("loading destination file...");
            var destinationResource = GetResource(textBox_Destination.Text, destinationKeyIndex, destinationEnglishIndex, destinationFrenchIndex, destinationFileIndex, destinationProjectIndex);

            this.UpdateStatus("copying resources...");
            destinationResource = TransferResources(sourceResource, destinationResource);

            //this.UpdateStatus("saving to destination file...");
            //SaveResourceToFile(destinationResource, textBox_Destination.Text);
            this.UpdateStatus("");

            this.dataGridView1.DataSource = destinationResource;
        }

        private void SaveResourceToFile(List<Resource> destinationResource, string filePath)
        {
            FileInfo file = new FileInfo(textBox_Destination.Text);

            using (var package = new ExcelPackage(file))
            {
                ExcelWorkbook workBook = package.Workbook;
                ExcelWorksheet currentWorksheet = workBook.Worksheets.FirstOrDefault();

                return;
                //int totalRows = currentWorksheet.Dimension.End.Row;
                //int totalCols = currentWorksheet.Dimension.End.Column;

                var i = 1;
                foreach (var resource in destinationResource)
                {
                    this.UpdateStatus($"saving to destination file...{i}/{destinationResource.Count}");
                    try
                    {
                        currentWorksheet.Cells[1, 1].Value = "hahahahahahahahah";
                        currentWorksheet.Cells[i, destinationEnglishIndex].Value = resource.English;
                        currentWorksheet.Cells[i, destinationFrenchIndex].Value = resource.French;
                    }
                    catch (Exception ex)
                    {
                    }
                    i++;
                }
                package.Save();
                this.UpdateStatus($"transfer complete!!!");
            }





        }

        private List<Resource> TransferResources(List<Resource> sourceResource, List<Resource> destinationResource)
        {
            var i = 0;
            foreach (var source in sourceResource)
            {
                this.UpdateStatus($"copying resources...{i}/{sourceResource.Count}");
                var destination = destinationResource.FirstOrDefault(r => r.Key == source.Key && r.File == source.File && r.Project == source.Project);
                if (destination != null)
                {
                    if (!string.IsNullOrWhiteSpace(source.English))
                    {
                        destination.English = source.English;
                    }
                    if (!string.IsNullOrWhiteSpace(source.French))
                    {
                        destination.French = source.French;
                    }
                   
                }
                else
                {
                    var x = 0;
                }
                i++;
            }
            return destinationResource;
        }

        private List<Resource> GetResource(string filePath, int keyIndex, int englishIndex, int frenchIndex, int fileIndex, int projectIndex)
        {
            FileInfo file = new FileInfo(filePath);

            using (var package = new ExcelPackage(file))
            {
                ExcelWorkbook workBook = package.Workbook;
                ExcelWorksheet currentWorksheet = workBook.Worksheets.FirstOrDefault();

                int rowCount = currentWorksheet.Dimension.End.Row;
                //int totalCols = currentWorksheet.Dimension.End.Column;

                var resources = new List<Resource>();

                for (int i = 1; i < rowCount; i++)
                {
                    
                    var resource = new Resource
                    {
                        Key = currentWorksheet.Cells[i, keyIndex]?.Value?.ToString(),
                        English = currentWorksheet.Cells[i, englishIndex]?.Value?.ToString(),
                        French = currentWorksheet.Cells[i, frenchIndex]?.Value?.ToString(),
                        File = currentWorksheet.Cells[i, fileIndex]?.Value?.ToString(),
                        Project = currentWorksheet.Cells[i, projectIndex]?.Value?.ToString(),
                        
                    };
                    resources.Add(resource);
                }
                return resources;
            }
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.C && e.Control)
            {
                // copy logic
                DataGridView dgv = sender as DataGridView;
                dgv.Select();
                DataObject o = dgv.GetClipboardContent();
                Clipboard.SetDataObject(o);
            }
        }
    }
}
