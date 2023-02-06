using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticSalesman
{
    public partial class Form1 : Form
    {
        private static TravelingSalesman salesman = null;
        private double generationsPerClick = -1.0;
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawCities(List<(float x, float y)> coordinates, PaintEventArgs e, Brush brush = null)
        {
            if (brush is null)
                brush = Brushes.Black;

            foreach (var coordinate in coordinates)
                DrawCircleAtPoint(e, coordinate.x, coordinate.y, 10f, brush);
        }

        private void DrawPath(List<(float x, float y)> coordinates, PaintEventArgs e, Pen pen = null)
        {
            (float x, float y) startPoint;
            (float x, float y) endPoint;

            startPoint = coordinates[0];

            // Draw the main path
            for( int index = 1; index < coordinates.Count; ++index)
            {
                endPoint = coordinates[index];
                DrawLineBetweenPoints(e, startPoint.x, startPoint.y, endPoint.x, endPoint.y, pen);
                startPoint = endPoint;
            }

            // Draw the final line
            endPoint = coordinates[0];
            DrawLineBetweenPoints(e, startPoint.x, startPoint.y, endPoint.x, endPoint.y, pen);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            //e.Graphics.DrawLine(pen, 20, 10, 300, 100);
        }

        (float x, float y) GetPixelFromCoordinate( float x, float y )
        {
            float padding_x = 100f; // left and right margin, in pixels
            float padding_y = 100f; // top and bottom margin, in pixels

            float max_x = 5f;   // x coordinate max value
            float max_y = 5f;   // y coordinate max value

            float pixels_per_unit_x = (pictureBox1.Width - padding_x * 2f) / max_x;
            float pixels_per_unit_y = (pictureBox1.Height - padding_y * 2f) / max_y;


            float x_pixel = x * pixels_per_unit_x + padding_x;
            float y_pixel = pictureBox1.Height - (y * pixels_per_unit_y + padding_y);

            return (x_pixel, y_pixel);
        }

        public void DrawLineBetweenPoints(PaintEventArgs e, float x1, float y1, float x2, float y2, Pen pen = null)
        {
            if (pen is null)
            {
                pen = Pens.Black;
                //pen.Width = 5f;
            }

            var start = GetPixelFromCoordinate(x1, y1);
            var end = GetPixelFromCoordinate(x2, y2);

            float delta_x = end.x - start.x;
            float delta_y = end.y - start.y;

            e.Graphics.DrawLine(pen, start.x, start.y, end.x, end.y);
        }

        public void DrawCircleAtPoint(PaintEventArgs e, float x, float y, float radius = 10f, Brush brush = null)
        {
            if (brush is null)
                brush = Brushes.Coral;

            var median = GetPixelFromCoordinate(x, y);

            float x_pixel = median.x;
            float y_pixel = median.y;

            e.Graphics.FillEllipse(brush, x_pixel - radius, y_pixel - radius, radius * 2f, radius * 2f);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Draw grid
            for( int x = 0; x <= 5; ++x)
            {
                for (int y = 0; y <= 5; ++y)
                    DrawCircleAtPoint(e, x, y, 3, Brushes.LightGray);
            }

            // Draw map and paths
            if (!(salesman is null))
            {
                if( checkBoxShowCities.CheckState == CheckState.Checked )
                    DrawCities(salesman.Map.Coordinates, e);

                if (checkBoxShowBestPath.CheckState == CheckState.Checked)
                    DrawPath(salesman.GetBestPathCoordinates(), e, new Pen(Brushes.LimeGreen, 5f));

                if( checkBoxShowWorst.CheckState == CheckState.Checked)
                    DrawPath(salesman.GetWorstPathCoordinates(), e, new Pen(Brushes.Salmon, 2f));

            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
        }

        private void buttonEvolve_Click(object sender, EventArgs e)
        {
            if (salesman is null)
                return;
         
            // Update ETA
            double generationsToDo;
            if (double.TryParse(textBoxGenerationsPerClick.Text, out generationsToDo) && generationsPerClick > 0)
            {
                double seconds = generationsToDo / generationsPerClick;
                TimeSpan span = TimeSpan.FromSeconds(seconds);
                toolStripStatusLabelEta.Text = $"ETA: {DateTime.Now + span}";
                //labelEvolveTime.Text = $"Estimated time to evolve: {span}";
            }
            else
            {
                toolStripStatusLabelEta.Text = $"ETA: ???";

                //labelEvolveTime.Text = $"Estimated time to evolve: ???";
            }
            //salesman.MutationRate = int.Parse(textBoxMutationRate.Text);




            toolStripExecutionStatus.Text = "RUNNING";
            toolStripExecutionStatus.BackColor = Color.Red;

            statusStrip1.Refresh();

            Stopwatch watch = Stopwatch.StartNew();
            
            salesman.Evolve(int.Parse(textBoxGenerationsPerClick.Text),
                addRandomParents: checkBoxRandomParents.Checked,
                addMutantClones: checkBoxClones.Checked,
                randomizeMutationRate: checkBoxRandomMutation.Checked
            );

            watch.Stop();

            toolStripExecutionStatus.Text = "READY";
            toolStripExecutionStatus.BackColor = Color.Green;
            statusStrip1.Refresh();

            pictureBox1.Refresh();
            textBoxMain.Text = salesman.ToString();

            generationsPerClick = double.Parse(textBoxGenerationsPerClick.Text) / (watch.Elapsed.TotalSeconds);
            UpdateTimeToEvolveLabel();
            toolStripStatusLabel1.Text = $"Last evolution: {int.Parse(textBoxGenerationsPerClick.Text):n0} generations in {watch.Elapsed.TotalSeconds} seconds. {generationsPerClick:n0} generations per second";

            toolStripStatusLabelEta.Text = "";
    }

        private void UpdateTimeToEvolveLabel()
        {
            double generationsToDo;
            if( double.TryParse(textBoxGenerationsPerClick.Text, out generationsToDo) && generationsPerClick > 0 )
            {
                double seconds = generationsToDo / generationsPerClick;
                TimeSpan span = TimeSpan.FromSeconds(seconds);

                labelEvolveTime.Text = $"Estimated time to evolve: {span}";
            }
            else
            {
                labelEvolveTime.Text = $"Estimated time to evolve: ???";
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxShowWorst_CheckStateChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void checkBoxShowWorst_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void checkBoxShowBestPath_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void checkBoxShowCities_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void buttonNewMap_Click(object sender, EventArgs e)
        {
            generationsPerClick = -1.0;
            UpdateTimeToEvolveLabel();

            int pathCount = int.Parse(textBoxPath.Text);
            int cityCount = int.Parse(textBoxCities.Text);

            salesman = new TravelingSalesman(cityCount, pathCount);

            //salesman.Map.Coordinates = new List<(float x, float y)>()
            //{
            //    (0f,0f),
            //    (0f,3f),
            //    (4f,3f),
            //    (4f,0f),
            //
            //};
            pictureBox1.Refresh();
            textBoxMain.Text = salesman.ToString();
        }

        private void textBoxGenerationsPerClick_TextChanged(object sender, EventArgs e)
        {
            UpdateTimeToEvolveLabel();
        }
    }
}
