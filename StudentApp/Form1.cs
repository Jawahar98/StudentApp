using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentApp
{
    public partial class Form1 : Form
    {
        string _path = @"C:\Users\Admin\Downloads\6208c4ffc6b6426e53178a48.json";
       // string _updatepath = @"C:\Users\Admin\Downloads\621c684c0d849b34c4a08a28.json";
        ClsQuestion.Root objAssessmentData;
        int SectionList = 0;
        int ItemList = 0;
        int timeleft = 0;
        int timeleft1 = 0;
        int timeleft2 = 0;
        int numberofseconds = 0;
        int qn = 0;
        int nos ;
       
        
            
        List<string> Items = new List<string>();

        RadioButton rbtn = new RadioButton();
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sectiontimer.Start();
            totaltimer.Start();
            itemtimer.Start();

            string jsonfromfile;
            //  string jsontofile;

            using (var reader = new StreamReader(_path))
            { jsonfromfile = reader.ReadToEnd(); }

            //using (var reader = new StreamReader(_updatepath))
            //{ jsontofile = reader.ReadToEnd(); }


            Items.Clear();
            DataSet ds = new DataSet();
            // var tmp = new JavaScriptSerializer().Deserialize<ClsQuestion.Root>(jsonfromfile);


            objAssessmentData = JsonConvert.DeserializeObject<ClsQuestion.Root>(jsonfromfile.ToString());
            lblquestion.Text = objAssessmentData.sections[SectionList].items[ItemList].stem.question.text;

            nos = objAssessmentData.settings.totalDuration;

            if(objAssessmentData.settings.answeringSequenceOfSection == "FREE_SEQUENCE")
            {
                sectiontimer.Enabled = false;
                timerlabel.Visible = false;
                label3.Visible = false;

            }
            else
            {
                sectiontimer.Enabled = true;
                timerlabel.Visible = true;
                label3.Visible = true;

                if (SectionList >= 0 && ItemList == 0)
                { button2.Hide();}
                else { button2.Show(); }
                
              
            }

            if (objAssessmentData.sections[SectionList].settings.answeringSequenceOfItem == "FREE_SEQUENCE")
            {    itemtimer.Enabled = false;
                itemtimerlabel.Visible = false;
                checkBox1.Visible = true;

            }
            else
            {
                
                itemtimer.Enabled = true;
              itemtimerlabel.Visible = true;
                 button2.Hide();   
                checkBox1.Visible = false;
                
               
            }

            lblqnum.Text = ++qn + ".";
            button2.Hide();

            timeleft = (objAssessmentData.sections[SectionList].duration);

            numberofseconds = objAssessmentData.sections[SectionList].duration;


            timeleft1 = objAssessmentData.settings.totalDuration;

            timeleft2 = (objAssessmentData.sections[SectionList].duration)/objAssessmentData.sections[SectionList].items.Count;


            checkBox1.Checked = false;

            for (int j = 1; j <= objAssessmentData.sections[SectionList].items.Count; j++)
            {
                UserControl1 us = new UserControl1(j);
                 us.iscurrentQsnBookmark = false; 
                flowLayoutPanel2.Controls.Add(us);

                UserControl3 us3 = new UserControl3(j);
                if (ItemList + 1 == j)
                {
                    us3.issectionindicated = true;
                }
                else
                {
                    us3.issectionindicated = false;
                }
                flowLayoutPanel4.Controls.Add(us3);


            }
            for (int i = 1; i <= objAssessmentData.sections.Count; i++)
            {
                UserControl2 us2 = new UserControl2(i);
                if (SectionList + 1 == i)
                { 
                    us2.issectionchanged = true;  
                }
                else
                {
                    us2.issectionchanged = false;
                }


                flowLayoutPanel3.Controls.Add(us2);

            }

            foreach (ClsQuestion.Option2 val in objAssessmentData.sections[SectionList].items[ItemList].options)
            {
                RadioButton rbtn = new RadioButton();
                rbtn.AutoSize = true;
                rbtn.Text = val.label + " . " + val.text;
                rbtn.Tag = val._id;
                if (val._id == objAssessmentData.sections[SectionList].items[ItemList].stem.question.answer._id)
                { rbtn.Checked = true; }


                flowLayoutPanel1.Controls.Add(rbtn);


            }
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                control.Click += new EventHandler(Eventhandler_click);
            }

            // XmlDocument xmlDoc = (XmlDocument)JsonConvert.DeserializeXmlNode("{ \"SessionData\": " + JsonConvert.SerializeObject(tmp).Trim() + " }");
            // ds.ReadXml(new XmlNodeReader(xmlDoc));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (objAssessmentData.sections[SectionList].items.Count - 1 > ItemList)
            {
              //  timeleft = timeleft - timeleft2;
               // timeleft2 = (objAssessmentData.sections[SectionList].duration) / objAssessmentData.sections[SectionList].items.Count;

                sectiontimer.Start();
                itemtimer.Start();

                int tmtn = numberofseconds - timeleft;
                objAssessmentData.sections[SectionList].items[ItemList].timeTaken = tmtn;
                string output = JsonConvert.SerializeObject(objAssessmentData, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(_path, output);

               // timeleft = numberofseconds;

                button2.Show();
                
                flowLayoutPanel1.Controls.Clear();
              //  flowLayoutPanel2.Controls.Clear();
                flowLayoutPanel3.Controls.Clear();
                flowLayoutPanel4.Controls.Clear();
               ItemList = ItemList + 1;


                if (objAssessmentData.settings.answeringSequenceOfSection == "FREE_SEQUENCE")
                {sectiontimer.Enabled = false;
                    timerlabel.Visible = false;
                    label3.Visible = false;

                }
                else
                {

                    sectiontimer.Enabled = true;
                    timerlabel.Visible = true;
                    label3.Visible = true;
                    if (SectionList >= 0 && ItemList == 0)
                    { button2.Hide(); }
                    else { button2.Show(); }

                }

                if (objAssessmentData.sections[SectionList].settings.answeringSequenceOfItem == "FREE_SEQUENCE")
                {
                   itemtimer.Enabled = false;
                    itemtimerlabel.Visible = false;
                    checkBox1.Visible = true;

                }
                else
                {
                    
                    itemtimer.Enabled = true;
                    timeleft = timeleft - timeleft2;
                    timeleft2 = (objAssessmentData.sections[SectionList].duration) / objAssessmentData.sections[SectionList].items.Count;
                    
                    itemtimerlabel.Visible = true;
                    button2.Hide();
                    checkBox1.Visible = false;
                   

                }


                lblquestion.Text = objAssessmentData.sections[SectionList].items[ItemList].stem.question.text;

                lblqnum.Text = (++qn) + ".";

                if (Items.Contains(objAssessmentData.sections[SectionList].items[ItemList]._id))
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;

                }
              

              

                for (int i = 1; i <= objAssessmentData.sections.Count; i++)
                {
                    UserControl2 us2 = new UserControl2(i);
                    if (SectionList + 1 == i)
                    {
                        us2.issectionchanged = true;
                    }
                    else
                    {
                        us2.issectionchanged = false;
                    }


                    flowLayoutPanel3.Controls.Add(us2);

                }

                for (int j = 1; j <= objAssessmentData.sections[SectionList].items.Count; j++)
                {
                    UserControl3 us3 = new UserControl3(j);
                    if (ItemList + 1 == j)
                    {
                        us3.issectionindicated = true;
                    }
                    else
                    {
                        us3.issectionindicated = false;
                    }
                    flowLayoutPanel4.Controls.Add(us3);

                }



                foreach (ClsQuestion.Option2 val in objAssessmentData.sections[SectionList].items[ItemList].options)
                {
                    RadioButton rbtn = new RadioButton();
                    rbtn.AutoSize = true;
                    rbtn.Text = val.label + " . " + val.text;
                    rbtn.Tag = val._id;
                    if (val._id == objAssessmentData.sections[SectionList].items[ItemList].stem.question.answer._id)
                    { rbtn.Checked = true; }

                    flowLayoutPanel1.Controls.Add(rbtn);

                }

                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    control.Click += new EventHandler(Eventhandler_click);
                }
            
            }

       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (objAssessmentData.sections[SectionList].items.Count > ItemList)
            {

                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel3.Controls.Clear();
                flowLayoutPanel4.Controls.Clear();
               
                if(ItemList == 0) { SectionList = SectionList - 1;
                    ItemList = objAssessmentData.sections[SectionList].items.Count - 1;
                    flowLayoutPanel2.Controls.Clear();
                    for (int j = 1; j <= (objAssessmentData.sections[SectionList].items.Count ); j++)
                    {
                        UserControl1 us = new UserControl1(j);

                        us.iscurrentQsnBookmark = false;

                        flowLayoutPanel2.Controls.Add(us);
                    }
                    }
                else { ItemList = ItemList - 1; }
                lblquestion.Text = objAssessmentData.sections[SectionList].items[ItemList].stem.question.text;

                lblqnum.Text = --qn + ".";

                if (objAssessmentData.settings.answeringSequenceOfSection == "FREE_SEQUENCE")
                {sectiontimer.Enabled = false;
                    timerlabel.Visible = false;
                    label3.Visible = false;

                }
                else
                {
                  sectiontimer.Enabled = true;
                    timerlabel.Visible = true;
                    label3.Visible = true;
                    if (SectionList >= 0 && ItemList == 0)

                    { button2.Hide(); }

                    else { button2.Show(); }

                   
                }

                if (objAssessmentData.sections[SectionList].settings.answeringSequenceOfItem == "FREE_SEQUENCE")
                {
                    itemtimer.Enabled = false;
                    itemtimerlabel.Visible = false;
                    checkBox1.Visible = true;

                }
                else
                {
                  

                    itemtimer.Enabled = true;
                    timeleft = timeleft - timeleft2;
                    timeleft2 = objAssessmentData.sections[SectionList].duration / objAssessmentData.sections[SectionList].items.Count;

                   
                    itemtimerlabel.Visible = true;
                    button2.Hide();
                    checkBox1.Visible = false;
                    
                }

                for (int i = 1; i <= objAssessmentData.sections.Count; i++)
                {

                    UserControl2 us2 = new UserControl2(i);
                    if (SectionList + 1 == i)
                    {
                        us2.issectionchanged = true;
                    }
                    else
                    {
                        us2.issectionchanged = false;
                    }
                    flowLayoutPanel3.Controls.Add(us2);
                }

                if (Items.Contains(objAssessmentData.sections[SectionList].items[ItemList]._id))
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                for (int j = 1; j <= objAssessmentData.sections[SectionList].items.Count; j++)
                {
                    UserControl3 us3 = new UserControl3(j);
                    if (ItemList  == j - 1)
                    {
                        us3.issectionindicated = true;
                    }
                    else
                    {
                        us3.issectionindicated = false;
                    }
                    flowLayoutPanel4.Controls.Add(us3);

                }

                foreach (ClsQuestion.Option2 val in objAssessmentData.sections[SectionList].items[ItemList].options)
                {
                    RadioButton rbtn = new RadioButton();
                    rbtn.AutoSize = true;

                    rbtn.Text = val.label + " . " + val.text;
                    rbtn.Tag = val._id;
                    if (val._id == objAssessmentData.sections[SectionList].items[ItemList].stem.question.answer._id)
                    { rbtn.Checked = true; }

                    flowLayoutPanel1.Controls.Add(rbtn);
                }
            }  
        }

        private void Eventhandler_click(object sender, EventArgs e)
        {
            var val = sender as RadioButton;
            string[] result = val.Text.ToString().Split('.');
            objAssessmentData.sections[SectionList].items[ItemList].stem.question.answer.text = result[1];
            objAssessmentData.sections[SectionList].items[ItemList].stem.question.answer.label = result[0];
            objAssessmentData.sections[SectionList].items[ItemList].stem.question.answer.displayLabel = result[0];
            objAssessmentData.sections[SectionList].items[ItemList].stem.question.answer._id = val.Tag.ToString();
            string output = JsonConvert.SerializeObject(objAssessmentData, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_path, output);
        }




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            flowLayoutPanel2.Controls.Clear();
            for (int j = 1; j <= objAssessmentData.sections[SectionList].items.Count; j++)
            {
                bool state = false;
                if (checkBox1.Checked)
                {

                    if (!Items.Contains(objAssessmentData.sections[SectionList].items[ItemList]._id))
                    {
                        Items.Add(objAssessmentData.sections[SectionList].items[ItemList]._id);
                    }

                }
                else
                {
                    if (Items.Contains(objAssessmentData.sections[SectionList].items[ItemList]._id))
                    {
                        Items.Remove(objAssessmentData.sections[SectionList].items[ItemList]._id);
                    }
                }
                if (Items.Contains(objAssessmentData.sections[SectionList].items[j - 1]._id))
                {
                    state = true;
                }
                else
                {
                    state = false;
                }

                UserControl1 us = new UserControl1(j);
                us.iscurrentQsnBookmark = state;
                flowLayoutPanel2.Controls.Add(us);
               
            }
            if (SectionList>0)
            {
                flowLayoutPanel2.Controls.Clear();
                for (int j = 11; j <= (objAssessmentData.sections[0].items.Count + objAssessmentData.sections[SectionList].items.Count); j++)
                {

                    bool state = false;
                    if (checkBox1.Checked)
                    {

                        if (!Items.Contains(objAssessmentData.sections[SectionList].items[ItemList]._id))
                        {
                            Items.Add(objAssessmentData.sections[SectionList].items[ItemList]._id);
                        }

                    }
                    else
                    {
                        if (Items.Contains(objAssessmentData.sections[SectionList].items[ItemList]._id))
                        {
                            Items.Remove(objAssessmentData.sections[SectionList].items[ItemList]._id);
                        }
                    }
                    if (Items.Contains(objAssessmentData.sections[SectionList].items[j - 11]._id))
                    {
                        state = true;
                    }
                    else
                    {
                        state = false;
                    }

                    UserControl1 us = new UserControl1(j);
                    us.iscurrentQsnBookmark = state;
                    flowLayoutPanel2.Controls.Add(us);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            if (timeleft > 0)
            {
                timeleft = timeleft - 1;

               TimeSpan ts = TimeSpan.FromSeconds(timeleft);
                string answer = string.Format("{0:D2}m:{1:D2}s",
                    ts.Minutes, ts.Seconds);
                timerlabel.Text = answer;
                sectiontimer.Start();

                if (timeleft == 0)
                {
                    sectiontimer.Stop();
                    button1.PerformClick();
                    timerlabel.Text = answer;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timeleft1 > 0)
            {
                timeleft1 = timeleft1 - 1;

                TimeSpan ts = TimeSpan.FromSeconds(timeleft1);
                string answer1 = string.Format("{0:D2}m:{1:D2}s",
                    ts.Minutes, ts.Seconds);
                tdnlabel.Text = answer1;
                totaltimer.Start();


            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (timeleft2 > 0)
            {
                timeleft2 = timeleft2 - 1;

                TimeSpan ts = TimeSpan.FromSeconds(timeleft2);
                string answer2 = string.Format("{0:D2}m:{1:D2}s",
                    ts.Minutes, ts.Seconds);
                itemtimerlabel.Text = answer2;
                itemtimer.Start();

                if (timeleft2 == 0)
                {
                    itemtimer.Stop();
                    button1.PerformClick();
                    itemtimerlabel.Text = answer2;
                }
            }
        }
    }
 } 

