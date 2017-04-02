using Microsoft.ProjectOxford.Vision.Contract;
using System;
using Microsoft.ProjectOxford.Vision;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CouldApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            AnalysisResult analysisResult;


            analysisResult = await UploadAndAnalyzeImage(@"C:\Users\Gayan Denaindra\Downloads\130214_QUORA_CUTE_N_OLD.jpg.CROP.article568-large.jpg");
        }

        private async Task<AnalysisResult> UploadAndAnalyzeImage(string v)
        {
            VisionServiceClient VisionServiceClient = new VisionServiceClient("2299c019574f473aa7ec51f94544778f ");
            using (Stream imageFileStream = File.OpenRead(v))
            {
                //
                // Analyze the image for all visual features
                //
                //Log("Calling VisionServiceClient.AnalyzeImageAsync()...");
                VisualFeature[] visualFeatures = new VisualFeature[] { VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color, VisualFeature.Description, VisualFeature.Faces, VisualFeature.ImageType, VisualFeature.Tags };
                AnalysisResult analysisResult = await VisionServiceClient.AnalyzeImageAsync(imageFileStream, visualFeatures);
                return analysisResult;
            }
        }
    }
}
