using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

using static WindowsFormsAppRuap.Studenti;


namespace WindowsFormsAppRuap
{


    public partial class Form1 : Form
    {
        public string[,] inputValues= new string[33,33];


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            inputValues[0, 0] = "value";
            inputValues[0, 4] = "value";
            inputValues[0, 8] = "value";
            inputValues[0, 9] = "value";
            inputValues[0, 10] = "value";
            inputValues[0, 32] = "0";

            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"school", "sex", "age", "address", "famsize", "Pstatus", "Medu", "Fedu", "Mjob", "Fjob", "reason", "guardian", "traveltime", "studytime", "failures", "schoolsup", "famsup", "paid", "activities", "nursery", "higher", "internet", "romantic", "famrel", "freetime", "goout", "Dalc", "Walc", "health", "absences", "G1", "G2", "G3"},
                                Values =new string[,] { { inputValues[0,0], inputValues[0,1], inputValues[0,2], inputValues[0,3], inputValues[0,4], inputValues[0,5], inputValues[0,6], inputValues[0,7], inputValues[0,8], inputValues[0,9], inputValues[0,10], inputValues[0,11], inputValues[0,12], inputValues[0,13], inputValues[0,14], inputValues[0,15], inputValues[0,16], inputValues[0,17], inputValues[0,18], inputValues[0,19], inputValues[0,20], inputValues[0,21], inputValues[0,22], inputValues[0,23], inputValues[0,24], inputValues[0,25], inputValues[0,26], inputValues[0,27], inputValues[0,28], inputValues[0,29], inputValues[0,30], inputValues[0,31], inputValues[0,32] } } // {  { "value", "value", "0", "value", "value", "value", "0", "0", "value", "value", "value", "value", "0", "0", "0", "value", "value", "value", "value", "value", "value", "value", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" } ,  { "value", "value", "0", "value", "value", "value", "0", "0", "value", "value", "value", "value", "0", "0", "0", "value", "value", "value", "value", "value", "value", "value", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },  }
    
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "IJkijT3IcdlmHWLYdtolAk1lkqNSsm1TTYkIV1AKEoihnHqc+aUEpCzs+YNMDTpzaA+Y56ifSrXUC045wxHFwg=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/ee7764b2357144ca906ce00a8a3041ee/services/2986a113c3e44896a19995595fe5d0f2/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false) 


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);


                if (response.IsSuccessStatusCode)
                {

                    string result = await response.Content.ReadAsStringAsync();

                    var value = JsonConvert.DeserializeObject<Root>(result);

                    string finalResult = value.Results.output1.value.getLastValue();

                    label1.Text = finalResult;

                    Console.WriteLine(value.Results.output1.value.getLastValue());

                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0,1] = "M";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0,1] = "F";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox22_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 2] = comboBox1.SelectedItem.ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 3] = "U";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 3] = "R";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 5]="T";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 5] = "A";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 6] = comboBox2.SelectedItem.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 7] = comboBox3.SelectedItem.ToString();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 11] = "mother";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 11] = "father";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 11] = "other";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 12] = comboBox4.SelectedItem.ToString();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 13] = comboBox5.SelectedItem.ToString();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 14] = comboBox6.SelectedItem.ToString();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 15] = "yes";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 15] = "no";
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 16] = "yes";
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 16] = "no";
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 17] = "yes";
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 17] = "no";
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 18] = "yes";
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 18] = "no";
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 19] = "yes";
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 19] = "no";
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 20] = "yes";
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 20] = "no";
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 21] = "yes";
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 21] = "no";
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0,22] = "yes";
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[0, 22] = "no";
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 23] = comboBox7.SelectedItem.ToString();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 24] = comboBox8.SelectedItem.ToString();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 25] = comboBox9.SelectedItem.ToString();
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 26] = comboBox10.SelectedItem.ToString();
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 27] = comboBox11.SelectedItem.ToString();
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 28] = comboBox12.SelectedItem.ToString();
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 30] = comboBox13.SelectedItem.ToString();
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[0, 31] = comboBox14.SelectedItem.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            inputValues[0, 29] = textBox1.Text;
        }
    }
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }
}
