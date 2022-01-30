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
        public string[] inputValues= new string[] { "value", "value", "0", "value", "value", "value", "0", "0", "value", "value", "value", "value", "0", "0", "0", "value", "value", "value", "value", "value", "value", "value", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };


        public Form1()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e)
        {

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
                                Values =new string[,] { { inputValues[0], inputValues[1], inputValues[2], inputValues[3], inputValues[4], inputValues[5],
                                        inputValues[6], inputValues[7], inputValues[8], inputValues[9], inputValues[10], inputValues[11], inputValues[12],
                                        inputValues[13], inputValues[14], inputValues[15], inputValues[16], inputValues[17], inputValues[18], inputValues[19],
                                        inputValues[20], inputValues[21], inputValues[22], inputValues[23], inputValues[24], inputValues[25], inputValues[26], 
                                        inputValues[27], inputValues[28], inputValues[29], inputValues[30], inputValues[31], inputValues[32] } } 
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

                    label2.Text = finalResult.Substring(0,5);


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


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[1] = "M";
            label2.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[1] = "F";
            label2.Text = "";
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[2] = comboBox1.SelectedItem.ToString();
            label2.Text = "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[3] = "U";
            label2.Text = "";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[3] = "R";
            label2.Text = "";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[5]="T";
            label2.Text = "";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[5] = "A";
            label2.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[6] = comboBox2.SelectedItem.ToString();
            label2.Text = "";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[7] = comboBox3.SelectedItem.ToString();
            label2.Text = "";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[11] = "mother";
            label2.Text = "";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[11] = "father";
            label2.Text = "";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[11] = "other";
            label2.Text = "";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[12] = comboBox4.SelectedItem.ToString();
            label2.Text = "";
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[13] = comboBox5.SelectedItem.ToString();
            label2.Text = "";
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[14] = comboBox6.SelectedItem.ToString();
            label2.Text = "";
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[15] = "yes";
            label2.Text = "";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[15] = "no";
            label2.Text = "";
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[16] = "yes";
            label2.Text = "";
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[16] = "no";
            label2.Text = "";
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[17] = "yes";
            label2.Text = "";
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[17] = "no";
            label2.Text = "";
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[18] = "yes";
            label2.Text = "";
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[18] = "no";
            label2.Text = "";
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[19] = "yes";
            label2.Text = "";
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[19] = "no";
            label2.Text = "";
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[20] = "yes";
            label2.Text = "";
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[20] = "no";
            label2.Text = "";
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[21] = "yes";
            label2.Text = "";
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[21] = "no";
            label2.Text = "";
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[22] = "yes";
            label2.Text = "";
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            inputValues[22] = "no";
            label2.Text = "";
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[23] = comboBox7.SelectedItem.ToString();
            label2.Text = "";
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[24] = comboBox8.SelectedItem.ToString();
            label2.Text = "";
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[25] = comboBox9.SelectedItem.ToString();
            label2.Text = "";
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[26] = comboBox10.SelectedItem.ToString();
            label2.Text = "";
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[27] = comboBox11.SelectedItem.ToString();
            label2.Text = "";
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[28] = comboBox12.SelectedItem.ToString();
            label2.Text = "";
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[30] = comboBox13.SelectedItem.ToString();
            label2.Text = "";
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputValues[31] = comboBox14.SelectedItem.ToString();
            label2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            inputValues[29] = textBox1.Text;
            label2.Text = "";
        }
    }
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }
}
