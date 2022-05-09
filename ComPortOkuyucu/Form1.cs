using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace ComPortOkuyucu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(item);
            }
            button3.Enabled = false;
            var conn = new SqlConnection(@"server=.;Database=Hasta_Takip;User ID=sa;Password=likompresto%1");

            textBox6.Text = "10.10.10.20";
            textBox7.Text = "sa";
            textBox8.Text = "likompresto%1";

            textBox2.Text = "19200";
            textBox3.Text = "8";
            textbox_4.Text = "0";
            textBox5.Text = "1";

            conn.Close();
            textBox1.ReadOnly = true;
            button6.Enabled = false;


            //"insert into Tam_Kan_tablo (" +
            //   "       [ID]" +
            //   "      ,[RBC]" +
            //   "      ,[MCV]" +
            //   "      ,[HCT]" +
            //   "      ,[MCH]" +
            //   "      ,[MCHC]" +
            //   "      ,[RDWR]" +
            //   "      ,[RDWA]" +
            //   "      ,[PLT]" +
            //   "      ,[MPV]" +
            //   "      ,[PCT]" +
            //   "      ,[PDW]" +
            //   "      ,[PDWR]" +
            //   "      ,[LPCR]" +
            //   "      ,[LPCA]" +
            //   "      ,[HGB]" +
            //   "      ,[WBC]" +
            //   "      ,[LA]" +
            //   "      ,[MA]" +
            //   "      ,[GA]" +
            //   "      ,[LR]" +
            //   "      ,[MR]" +
            //   "      ,[GR]" +
            //   "      ,[PLT_Grafik]" +
            //   "      ,[RBC_Grafik]" +
            //   "      ,[WBC_LYM]" +
            //   "      ,[WBC_MID]" +
            //   "      ,
            //"      ,[WBC_LYM]" +
            //   "      ,[WBC_MID]" +
            //   "      ,[WBC_GRA],[Tarih]" +
            dataGridView1.Columns.Add("Barkod", "Barkod");
            dataGridView1.Columns.Add("Tarih", "Tarih");
            dataGridView1.Columns.Add("RBC", "RBC");
            dataGridView1.Columns.Add("MCV", "MCV");
            dataGridView1.Columns.Add("HCT", "HCT");
            dataGridView1.Columns.Add("MCH", "MCH");
            dataGridView1.Columns.Add("MCHC", "MCHC");
            dataGridView1.Columns.Add("RDWR", "RDWR");
            dataGridView1.Columns.Add("RDWA", "RDWA");
            dataGridView1.Columns.Add("PLT", "PLT");
            dataGridView1.Columns.Add("MPV", "MPV");
            dataGridView1.Columns.Add("PCT", "PCT");
            dataGridView1.Columns.Add("PDW", "PDW");
            dataGridView1.Columns.Add("PDWR", "PDWR");
            dataGridView1.Columns.Add("LPCR", "LPCR");
            dataGridView1.Columns.Add("HGB", "HGB");
            dataGridView1.Columns.Add("WBC", "WBC");
            dataGridView1.Columns.Add("LA", "LA");
            dataGridView1.Columns.Add("MA", "MA");
            dataGridView1.Columns.Add("GA", "GA");
            dataGridView1.Columns.Add("LR", "LR");
            dataGridView1.Columns.Add("MR", "MR");
            dataGridView1.Columns.Add("GR", "GR");
            dataGridView1.Columns.Add("PLT_Grafik", "PLT_Grafik");
            dataGridView1.Columns.Add("RBC_Grafik", "RBC_Grafik");
            dataGridView1.Columns.Add("WBC_LYM", "WBC_LYM");
            dataGridView1.Columns.Add("WBC_MID", "WBC_MID");
            dataGridView1.Columns.Add("WBC_GRA", "WBC_GRA");




        }
        //class sampe
        //{
        //    public string Ad { get; set; }
        //    public string Değer { get; set; }
        //}
        public class p
        {

            [XmlElement(ElementName = "n")]
            public string n;

            [XmlElement(ElementName = "v")]
            public string v;

            [XmlElement(ElementName = "l")]
            public double l;

            [XmlElement(ElementName = "h")]
            public double h;

            [XmlElement(ElementName = "el")]
            public object el;

            [XmlElement(ElementName = "eh")]
            public object eh;
        }

        [XmlRoot(ElementName = "instrinfo")]
        public class instrinfo
        {

            [XmlElement(ElementName = "p")]
            public List<p> p;
        }

        [XmlRoot(ElementName = "smpinfo")]
        public class smpinfo
        {

            [XmlElement(ElementName = "p")]
            public List<p> p;
        }

        [XmlRoot(ElementName = "smpresults")]
        public class smpresults
        {

            [XmlElement(ElementName = "p")]
            public List<p> p;
        }

        [XmlRoot(ElementName = "tparams")]
        public class tparams
        {

            [XmlElement(ElementName = "p")]
            public List<p> p;
        }

        [XmlRoot(ElementName = "hgdata")]
        public class hgdata
        {

            [XmlElement(ElementName = "v")]
            public string v;

            [XmlElement(ElementName = "n")]
            public string n;
        }

        [XmlRoot(ElementName = "hgram")]
        public class hgram
        {

            [XmlElement(ElementName = "hgdata")]
            public List<hgdata> hgdata;

            [XmlElement(ElementName = "n")]
            public string n;

            [XmlElement(ElementName = "m")]
            public string m;

            [XmlElement(ElementName = "k")]
            public string k;

            [XmlElement(ElementName = "w")]
            public string w;

            [XmlElement(ElementName = "d")]
            public string d;
        }

        [XmlRoot(ElementName = "hgrams")]
        public class hgrams
        {

            [XmlElement(ElementName = "hgram")]
            public List<hgram> hgram;

          
        }

        [XmlRoot(ElementName = "cf")]
        public class cf
        {

            [XmlElement(ElementName = "n")]
            public string n;

            [XmlElement(ElementName = "v")]
            public double v;
        }

        [XmlRoot(ElementName = "rawv")]
        public class rawv
        {

            [XmlElement(ElementName = "n")]
            public string n;

            [XmlElement(ElementName = "m")]
            public int m;

            [XmlElement(ElementName = "b")]
            public int b;

            [XmlElement(ElementName = "c")]
            public int c;

            [XmlElement(ElementName = "k")]
            public int k;

            [XmlElement(ElementName = "cte")]
            public string cte;

            [XmlElement(ElementName = "ccp")]
            public string ccp;

            [XmlElement(ElementName = "v")]
            public string v;
        }

        [XmlRoot(ElementName = "ccompr")]
        public class ccompr
        {

            [XmlElement(ElementName = "ccctr")]
            public int ccctr;

            [XmlElement(ElementName = "ccwra")]
            public int ccwra;

            [XmlElement(ElementName = "ccwrr")]
            public int ccwrr;

            [XmlElement(ElementName = "ccwpa")]
            public int ccwpa;

            [XmlElement(ElementName = "ccwpr")]
            public int ccwpr;

            [XmlElement(ElementName = "ccnra")]
            public int ccnra;

            [XmlElement(ElementName = "ccnrr")]
            public int ccnrr;

            [XmlElement(ElementName = "ccnpa")]
            public int ccnpa;

            [XmlElement(ElementName = "ccnpr")]
            public int ccnpr;

            [XmlElement(ElementName = "cctrr")]
            public int cctrr;

            [XmlElement(ElementName = "ccbtr")]
            public int ccbtr;

            [XmlElement(ElementName = "ccbtp")]
            public int ccbtp;
        }

        [XmlRoot(ElementName = "mcvtc")]
        public class mcvtc
        {

            [XmlElement(ElementName = "a")]
            public int a;

            [XmlElement(ElementName = "mtctype")]
            public int mtctype;

            [XmlElement(ElementName = "mtcv")]
            public int mtcv;

            [XmlElement(ElementName = "mtci")]
            public int mtci;

            [XmlElement(ElementName = "mtct")]
            public int mtct;

            [XmlElement(ElementName = "mtcr")]
            public int mtcr;

            [XmlElement(ElementName = "mtcq")]
            public int mtcq;

            [XmlElement(ElementName = "mtcve")]
            public int mtcve;

            [XmlElement(ElementName = "mtcie")]
            public int mtcie;

            [XmlElement(ElementName = "mtcte")]
            public int mtcte;

            [XmlElement(ElementName = "mtcre")]
            public int mtcre;

            [XmlElement(ElementName = "mtcqe")]
            public int mtcqe;
        }

        [XmlRoot(ElementName = "rawred")]
        public class rawred
        {

            [XmlElement(ElementName = "cf")]
            public List<cf> cf;

            [XmlElement(ElementName = "rawv")]
            public List<rawv> rawv;

            [XmlElement(ElementName = "p")]
            public List<p> p;

            [XmlElement(ElementName = "ccompr")]
            public ccompr ccompr;

            [XmlElement(ElementName = "mcvtc")]
            public mcvtc mcvtc;
        }

        [XmlRoot(ElementName = "ccompw")]
        public class ccompw
        {

            [XmlElement(ElementName = "ccctw")]
            public int ccctw;

            [XmlElement(ElementName = "ccwwa")]
            public int ccwwa;

            [XmlElement(ElementName = "ccwwr")]
            public int ccwwr;

            [XmlElement(ElementName = "ccnwa")]
            public int ccnwa;

            [XmlElement(ElementName = "ccnwr")]
            public int ccnwr;

            [XmlElement(ElementName = "cctrw")]
            public int cctrw;

            [XmlElement(ElementName = "ccbtw")]
            public int ccbtw;
        }

        [XmlRoot(ElementName = "rawwht")]
        public class rawwht
        {

            [XmlElement(ElementName = "cf")]
            public cf cf;

            [XmlElement(ElementName = "rawv")]
            public rawv rawv;

            [XmlElement(ElementName = "p")]
            public List<p> p;

            [XmlElement(ElementName = "ccompw")]
            public ccompw ccompw;
        }

        [XmlRoot(ElementName = "ccompx")]
        public class ccompx
        {

            [XmlElement(ElementName = "ccctx")]
            public int ccctx;

            [XmlElement(ElementName = "ccwxa")]
            public int ccwxa;

            [XmlElement(ElementName = "ccwxr")]
            public int ccwxr;

            [XmlElement(ElementName = "ccwqa")]
            public int ccwqa;

            [XmlElement(ElementName = "ccwqr")]
            public int ccwqr;

            [XmlElement(ElementName = "ccnxa")]
            public int ccnxa;

            [XmlElement(ElementName = "ccnxr")]
            public int ccnxr;

            [XmlElement(ElementName = "ccnqa")]
            public int ccnqa;

            [XmlElement(ElementName = "ccnqr")]
            public int ccnqr;
        }

        [XmlRoot(ElementName = "rawrxc")]
        public class rawrxc
        {

            [XmlElement(ElementName = "p")]
            public List<p> p;

            [XmlElement(ElementName = "ccompx")]
            public ccompx ccompx;
        }

        [XmlRoot(ElementName = "rdp")]
        public class rdp
        {

            [XmlElement(ElementName = "n")]
            public string n;

            [XmlElement(ElementName = "sl")]
            public int sl;

            [XmlElement(ElementName = "sh")]
            public int sh;

            [XmlElement(ElementName = "k")]
            public int k;

            [XmlElement(ElementName = "v")]
            public string v;
        }

        [XmlRoot(ElementName = "rawhgb")]
        public class rawhgb
        {

            [XmlElement(ElementName = "cf")]
            public cf cf;

            [XmlElement(ElementName = "a")]
            public int a;

            [XmlElement(ElementName = "rdp")]
            public List<rdp> rdp;
        }

        [XmlRoot(ElementName = "rawdata")]
        public class rawdata
        {

            [XmlElement(ElementName = "ccf")]
            public double ccf;

            [XmlElement(ElementName = "rawred")]
            public rawred rawred;

            [XmlElement(ElementName = "rawwht")]
            public rawwht rawwht;

            [XmlElement(ElementName = "rawrxc")]
            public rawrxc rawrxc;

            [XmlElement(ElementName = "rawhgb")]
            public rawhgb rawhgb;
        }

        [XmlRoot(ElementName = "sample")]
        public class sample
        {

            [XmlElement(ElementName = "ver")]
            public string ver;

            [XmlElement(ElementName = "instrinfo")]
            public instrinfo instrinfo;

            [XmlElement(ElementName = "smpinfo")]
            public smpinfo smpinfo;

            [XmlElement(ElementName = "smpresults")]
            public smpresults smpresults;

            [XmlElement(ElementName = "tparams")]
            public tparams tparams;

            [XmlElement(ElementName = "hgrams")]
            public hgrams hgrams;

            [XmlElement(ElementName = "rawdata")]
            public rawdata rawdata;
        }

        class Grafikler
        {
            public string Grafik_Ad { get; set; }
            public string Değer { get; set; }
        }
        public sample Parse_Xml(string Xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(sample));
            using (StringReader reader = new StringReader(Xml))
            {
                var test = (sample)serializer.Deserialize(reader);
                return test;
            }

          
        }
        public delegate void Veri_Tabanına_Yaz(String Xml);
        public void Veri_Tabanına_Yaz__(String Xml)
        {
            textBox1.Text += Xml;
        }
        public void textboxsil(String Xml)
        {
            textBox1.Text = "";
        }

        public string Gelen_Değer { get; set; }
        public class Tam_Kan_Tablo
        {
            public string Değer_Adı { get; set; }
            public string Değer { get; set; }
        }
        public void Veri_Tabanına_Yaz_(String Xml)
        {
            //MessageBox.Show("Gönderim Başlıyor");


            //textBox1.Text += Xml.ToString();

            var Temp = Parse_Xml(Xml);
            //XmlSerializer serializer = new XmlSerializer(typeof(sample));
            //using (StringReader reader = new StringReader(Xml))
            //{
            //    var test = (sample)serializer.Deserialize(reader);
            //}
            //textBox1.Text += "asdasdasd";


            var Tablo = (from Data in Temp.smpresults.p
                         select new
                         {
                             Data.n,
                             Data.v
                         });




            IList<Tam_Kan_Tablo> Gönderilecek = Tablo.Select(o => new Tam_Kan_Tablo
            {
                Değer = o.v,
                Değer_Adı = o.n
            }).ToList();


            var Grafik_Tablo = (from Data in Temp.smpresults.p
                                select new
                                {
                                    Data.n,
                                    Data.v
                                });


            IList<Tam_Kan_Tablo> Gönderilecek_Grafik = Grafik_Tablo.Select(o => new Tam_Kan_Tablo
            {
                Değer = o.v,
                Değer_Adı = o.n
            }).ToList();


            //Tam_Kan_Tablo X_1 = new Tam_Kan_Tablo
            //{
            //    Değer_Adı = "PLT_Grafik",
            //    Değer = (Temp.hgrams.hgram.FirstOrDefault(o => o.hgdata.FirstOrDefault(x => x.n == "PLT").n == "PLT").hgdata.FirstOrDefault(o => o.v == o.v).v)
            //};
            //Gönderilecek_Grafik.Add(X_1);

            //Tam_Kan_Tablo X_2 = new Tam_Kan_Tablo
            //{
            //    Değer_Adı = "RBC_Grafik",
            //    Değer = (Temp.hgrams.hgram.FirstOrDefault(o => o.n == "RBC").hgdata.FirstOrDefault(o => o.v == o.v).v)
            //};
            //Gönderilecek_Grafik.Add(X_2);


            //Tam_Kan_Tablo X_3 = new Tam_Kan_Tablo
            //{
            //    Değer_Adı = "WBC_LYM",
            //    Değer = (Temp.hgrams.hgram.FirstOrDefault(o => o.hgdata.FirstOrDefault(x=> x.n=="WBC").n == "WBC").hgdata.FirstOrDefault(o => o.n == "LYM").v)
            //};
            //Gönderilecek_Grafik.Add(X_3);

            //Tam_Kan_Tablo X_4 = new Tam_Kan_Tablo
            //{
            //    Değer_Adı = "WBC_MID",
            //    Değer = (Temp.hgrams.hgram.FirstOrDefault(o => o.hgdata.FirstOrDefault(x=> x.n=="WBC").n == "WBC").hgdata.FirstOrDefault(o => o.n == "MID").v)
            //};
            //Gönderilecek_Grafik.Add(X_4);

            //Tam_Kan_Tablo X_5 = new Tam_Kan_Tablo
            //{
            //    Değer_Adı = "WBC_GRA",
            //    Değer = (Temp.hgrams.hgram.FirstOrDefault(o => o.hgdata.FirstOrDefault(x => x.n == "WBC").n == "WBC").hgdata.FirstOrDefault(o => o.n == "GRA").v)
            //};
            //Gönderilecek_Grafik.Add(X_5);


            //cmd.Parameters.AddWithValue("@PLT_Grafik", Temp.hgrams.hgram.FirstOrDefault(o => o.n == "PLT").hgdata.FirstOrDefault(o => o.v == o.v).v);
            //cmd.Parameters.AddWithValue("@RBC_Grafik", Temp.hgrams.hgram.FirstOrDefault(o => o.n == "RBC").hgdata.FirstOrDefault(o => o.v == o.v).v);
            //cmd.Parameters.AddWithValue("@WBC_LYM", Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.FirstOrDefault(o => o.n == "LYM").v);
            //cmd.Parameters.AddWithValue("@WBC_MID", Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.FirstOrDefault(o => o.n == "MID").v);
            //cmd.Parameters.AddWithValue("@WBC_GRA", Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.FirstOrDefault(o => o.n == "GRA").v);



            DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(Gönderilecek));
            DataTable dataTable_Grafik = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(Gönderilecek_Grafik));
            var queryWithForJson = "" +
                "insert into Tam_Kan_tablo (" +
                "       [ID]" +
                "      ,[RBC]" +
                "      ,[MCV]" +
                "      ,[HCT]" +
                "      ,[MCH]" +
                "      ,[MCHC]" +
                "      ,[RDWR]" +
                "      ,[RDWA]" +
                "      ,[PLT]" +
                "      ,[MPV]" +
                "      ,[PCT]" +
                "      ,[PDW]" +
                "      ,[PDWR]" +
                "      ,[LPCR]" +
                "      ,[LPCA]" +
                "      ,[HGB]" +
                "      ,[WBC]" +
                "      ,[LA]" +
                "      ,[MA]" +
                "      ,[GA]" +
                "      ,[LR]" +
                "      ,[MR]" +
                "      ,[GR]" +
                "      ,[PLT_Grafik]" +
                "      ,[RBC_Grafik]" +
                "      ,[WBC_LYM]" +
                "      ,[WBC_MID]" +
                "      ,[WBC_GRA],[Tarih]" +
                ")" +
                "values(@ID,@RBC,@MCV,@HCT,@MCH,@MCHC,@RDWR,@RDWA,@PLT,@MPV,@PCT,@PDW,@PDWR,@LPCR,@LPCA,@HGB,@WBC,@LA,@MA,@GA,@LR,@MR,@GR,@PLT_Grafik,@RBC_Grafik,@WBC_LYM,@WBC_MID,@WBC_GRA,@Tarih)" +
                " " +
                "" +
                "" +
                " update Hasta_Biyoloji_Tekik_Değer set Tekik_Sayısal_Değer=Değer from @Tam_Kan_Tablo " +
                "" +
                " inner join Biyoloji_Tekik_Değer " +
                " on Değer_Adı=Biyoloji_Tekik_Değer.Tekik_Değer " +
                "" +
                "" +

                "" +
                "" +
                " where Biyoloji_Tekik_Değer.ID=Hasta_Biyoloji_Tekik_Değer.Biyoloji_Tekik_Değer and Hasta_Biyoloji_Tekik_Değer.Hasta_Biyoloji_Tekik_Değer_Genel_ID  " +
                "" +
                " in (" +
                " select Hasta_Biyoloji_Tekik_Değer_Genel.ID from Hasta_Biyoloji_Tetkik_Barkod " +
                " inner join Hasta_Biyoloji_Tekik_Değer_Genel " +
                " on Hasta_Biyoloji_Tekik_Değer_Genel.ID=Hasta_Biyoloji_Tetkik_Barkod.Hasta_Biyoloji_Tekik_Değer_Genel_ID " +
                 " where Hasta_Biyoloji_Tetkik_Barkod.Barkod=@Barkod " +
                " ) " +


                 " update Hasta_Biyoloji_Tekik_Değer set Tekik_Sayısal_Sözel=Değer from @Tam_Kan_Tablo_Grafik " +
                "" +
                " inner join Biyoloji_Tekik_Değer " +
                " on Değer_Adı=Biyoloji_Tekik_Değer.Tekik_Değer " +
                "" +
                "" +
                "" +
                "" +
                " where Biyoloji_Tekik_Değer.ID=Hasta_Biyoloji_Tekik_Değer.Biyoloji_Tekik_Değer and Hasta_Biyoloji_Tekik_Değer.Hasta_Biyoloji_Tekik_Değer_Genel_ID  " +
                "" +
                " in (" +
                " select Hasta_Biyoloji_Tekik_Değer_Genel.ID from Hasta_Biyoloji_Tetkik_Barkod " +
                " inner join Hasta_Biyoloji_Tekik_Değer_Genel " +
                " on Hasta_Biyoloji_Tekik_Değer_Genel.ID=Hasta_Biyoloji_Tetkik_Barkod.Hasta_Biyoloji_Tekik_Değer_Genel_ID " +
                 " where Hasta_Biyoloji_Tetkik_Barkod.Barkod=@Barkod " +
                " ) " +
                "" +
                "  " +
                "update Randevu set Randevu_Durumu=2 where Randevu_Id=( " +
                "select top 1 Randevu_Id from Hasta_Biyoloji_Tetkik_Barkod " +
                "inner join Hasta_Biyoloji_Tekik_Değer_Genel " +
                "on Hasta_Biyoloji_Tekik_Değer_Genel.ID=Hasta_Biyoloji_Tekik_Değer_Genel_ID where Hasta_Biyoloji_Tetkik_Barkod.Barkod =@ID) " +
                "" +
                "";



            string Server = textBox6.Text;
            string USER_ID = textBox7.Text;
            string pass = textBox8.Text;

            var conn = new SqlConnection(@"server=" + Server + ";Database=Hasta_Takip;User ID=" + USER_ID + ";Password=" + pass);
            var cmd = new SqlCommand(queryWithForJson, conn);

            //Tam_Kan_Type

            cmd.Parameters.AddWithValue("@Barkod", Temp.smpinfo.p.FirstOrDefault(o => o.n == "ID").v.ToString());
            cmd.Parameters.AddWithValue("@ID", Temp.smpinfo.p.FirstOrDefault(o => o.n == "ID").v.ToString());
            cmd.Parameters.AddWithValue("@RBC", Temp.smpresults.p.FirstOrDefault(o => o.n == "RBC").v.ToString());
            cmd.Parameters.AddWithValue("@MCV", Temp.smpresults.p.FirstOrDefault(o => o.n == "MCV").v.ToString());
            cmd.Parameters.AddWithValue("@HCT", Temp.smpresults.p.FirstOrDefault(o => o.n == "HCT").v.ToString());
            cmd.Parameters.AddWithValue("@MCH", Temp.smpresults.p.FirstOrDefault(o => o.n == "MCH").v.ToString());
            cmd.Parameters.AddWithValue("@MCHC", Temp.smpresults.p.FirstOrDefault(o => o.n == "MCHC").v.ToString());
            cmd.Parameters.AddWithValue("@RDWR", Temp.smpresults.p.FirstOrDefault(o => o.n == "RDWR").v.ToString());
            cmd.Parameters.AddWithValue("@RDWA", Temp.smpresults.p.FirstOrDefault(o => o.n == "RDWA").v.ToString());
            cmd.Parameters.AddWithValue("@PLT", Temp.smpresults.p.FirstOrDefault(o => o.n == "PLT").v.ToString());
            cmd.Parameters.AddWithValue("@MPV", Temp.smpresults.p.FirstOrDefault(o => o.n == "MPV").v.ToString());
            cmd.Parameters.AddWithValue("@PCT", Temp.smpresults.p.FirstOrDefault(o => o.n == "PCT").v.ToString());
            cmd.Parameters.AddWithValue("@PDW", Temp.smpresults.p.FirstOrDefault(o => o.n == "PDW").v.ToString());
            cmd.Parameters.AddWithValue("@PDWR", Temp.smpresults.p.FirstOrDefault(o => o.n == "PDWR").v.ToString());
            cmd.Parameters.AddWithValue("@LPCR", Temp.smpresults.p.FirstOrDefault(o => o.n == "LPCR").v.ToString());
            cmd.Parameters.AddWithValue("@LPCA", Temp.smpresults.p.FirstOrDefault(o => o.n == "LPCA").v.ToString());
            cmd.Parameters.AddWithValue("@HGB", Temp.smpresults.p.FirstOrDefault(o => o.n == "HGB").v.ToString());
            cmd.Parameters.AddWithValue("@WBC", Temp.smpresults.p.FirstOrDefault(o => o.n == "WBC").v.ToString());
            cmd.Parameters.AddWithValue("@LA", Temp.smpresults.p.FirstOrDefault(o => o.n == "LA").v.ToString());
            cmd.Parameters.AddWithValue("@MA", Temp.smpresults.p.FirstOrDefault(o => o.n == "MA").v.ToString());
            cmd.Parameters.AddWithValue("@GA", Temp.smpresults.p.FirstOrDefault(o => o.n == "GA").v.ToString());
            cmd.Parameters.AddWithValue("@LR", Temp.smpresults.p.FirstOrDefault(o => o.n == "LR").v.ToString());
            cmd.Parameters.AddWithValue("@MR", Temp.smpresults.p.FirstOrDefault(o => o.n == "MR").v.ToString());
            cmd.Parameters.AddWithValue("@GR", Temp.smpresults.p.FirstOrDefault(o => o.n == "GR").v.ToString());
            cmd.Parameters.AddWithValue("@PLT_Grafik", Temp.hgrams.hgram.FirstOrDefault(o => o.n == "PLT").hgdata.FirstOrDefault(o => o.v == o.v).v);
            cmd.Parameters.AddWithValue("@RBC_Grafik", Temp.hgrams.hgram.FirstOrDefault(o => o.n == "RBC").hgdata.FirstOrDefault(o => o.v == o.v).v);
            cmd.Parameters.AddWithValue("@WBC_LYM", Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.FirstOrDefault(o => o.n == "LYM").v);
            cmd.Parameters.AddWithValue("@WBC_MID", Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.FirstOrDefault(o => o.n == "MID").v);
            cmd.Parameters.AddWithValue("@WBC_GRA", Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.FirstOrDefault(o => o.n == "GRA").v);
            cmd.Parameters.AddWithValue("@Tarih", Temp.smpinfo.p.FirstOrDefault(o => o.n == "DATE").v);

            SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Tam_Kan_Tablo", dataTable);
            tvpParam.SqlDbType = SqlDbType.Structured;
            tvpParam.TypeName = "dbo.Tam_Kan_Type";
            SqlParameter tvpParam_ = cmd.Parameters.AddWithValue("@Tam_Kan_Tablo_Grafik", dataTable_Grafik);
            tvpParam_.SqlDbType = SqlDbType.Structured;
            tvpParam_.TypeName = "dbo.Tam_Kan_Type";
            conn.Open();




            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                jsonResult.Append("[]");
            }
            else
            {
                while (reader.Read())
                {


                }
            }
            conn.Close();


            dataGridView1.Rows.Add(
            Temp.smpinfo.p.FirstOrDefault(o => o.n == "ID").v.ToString(),
            Temp.smpinfo.p.FirstOrDefault(o => o.n == "DATE").v,
            Temp.smpresults.p.FirstOrDefault(o => o.n == "RBC").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "MCV").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "HCT").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "MCH").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "MCHC").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "RDWR").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "RDWA").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "PLT").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "MPV").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "PCT").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "PDW").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "PDWR").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "LPCR").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "LPCA").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "HGB").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "WBC").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "LA").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "MA").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "GA").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "LR").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "MR").v.ToString(),
            Temp.smpresults.p.FirstOrDefault(o => o.n == "GR").v.ToString(),
            Temp.hgrams.hgram.FirstOrDefault(o => o.n == "PLT").hgdata.FirstOrDefault(o => o.v == o.v).v,
            Temp.hgrams.hgram.FirstOrDefault(o => o.n == "RBC").hgdata.FirstOrDefault(o => o.v == o.v).v,
            Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.FirstOrDefault(o => o.n == "LYM").v,
            Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.FirstOrDefault(o => o.n == "MID").v,
            Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.FirstOrDefault(o => o.n == "GRA").v



                );





            textBox1.Invoke(new Veri_Tabanına_Yaz(textboxsil), "");

        }


        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            // try
            //{
            //    System.IO.Ports.SerialPort SP = (System.IO.Ports.SerialPort)sender;

            //    //Get the ports available in system
            //    string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();
            //    string strAvlPortNames = "";
            //    foreach (string s in theSerialPortNames)
            //    {
            //        strAvlPortNames += s.ToString() + ", ";
            //    }

            //    //Read an contruct the message
            //    //Thread.Sleep(1000);
            //    string msg = SP.ReadExisting();
            //    string ConstructedMsg = "Port's Found : " + strAvlPortNames + "\n" + "Port Used : " + SP.PortName + "\n" + "Message Received : " + msg;

            //    if (InvokeRequired)
            //    {
            //        textBox1.Invoke(new MethodInvoker(delegate { textBox1.Text = ConstructedMsg; }));
            //        //Send acknowlegement to sender port
            //        MessageBox.Show(msg);
            //        SP.Write(SP.PortName);
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.StackTrace.ToString());
            //}

            string Gelenveri = serialPort1.ReadExisting();

            if (Gelenveri != null)
            {
                if (!(textBox1.Text.IndexOf("</sample>") == -1))
                {
                    string verigönderilecek = textBox1.Text;
                    MessageBox.Show(verigönderilecek);
                    textBox1.Invoke(new Veri_Tabanına_Yaz(Veri_Tabanına_Yaz_), verigönderilecek);
                    textBox1.Invoke(new Veri_Tabanına_Yaz(textboxsil), "");

                }
                else
                {
                    //MessageBox.Show(textBox1.Text);
                    if ((Gelenveri.IndexOf("</sample>") > -1))
                    {

                        textBox1.Invoke(new Veri_Tabanına_Yaz(Veri_Tabanına_Yaz__), Gelenveri);
                        string verigönderilecek = textBox1.Text;
                        textBox1.Invoke(new Veri_Tabanına_Yaz(Veri_Tabanına_Yaz_), verigönderilecek);
                        textBox1.Invoke(new Veri_Tabanına_Yaz(textboxsil), "");

                    }

                    textBox1.Invoke(new Veri_Tabanına_Yaz(Veri_Tabanına_Yaz__), Gelenveri);



                }
                //if (!(Gelenveri == ""))
                //{

            }

            ////}






        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                button1.Enabled = true;
                button3.Enabled = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //@"server=192.168.1.28;Database=Hasta_Takip;User ID=sa;Password=likompresto%1"
                string connetionString;
                SqlConnection cnn;
                string Server = textBox6.Text;
                string USER_ID = textBox7.Text;
                string pass = textBox8.Text;

                connetionString = @"server=" + Server + ";Database=Hasta_Takip;User ID=" + USER_ID + ";Password=" + pass;
                // connetionString = @"server=rec4i.com;Database=Hasta_Takip;User ID=sa;Password=likompresto%1";

                cnn = new SqlConnection(connetionString);
                cnn.Open();
                MessageBox.Show("Connection Sucsess  !");
                cnn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string connetionString;
                    SqlConnection cnn;
                    string Server = textBox6.Text;
                    string USER_ID = textBox7.Text;
                    string pass = textBox8.Text;

                    connetionString = @"server=" + Server + ";Database=Hasta_Takip;User ID=" + USER_ID + ";Password=" + pass;
                    // connetionString = @"server=rec4i.com;Database=Hasta_Takip;User ID=sa;Password=likompresto%1";

                    cnn = new SqlConnection(connetionString);
                    cnn.Open();
                    MessageBox.Show("Connection Sucsess  !");
                    cnn.Close();




                    if (textBox6.Enabled == true)
                    {
                        textBox6.Enabled = false;
                    }
                    else
                    {
                        textBox6.Enabled = true;
                    }

                    if (textBox7.Enabled == true)
                    {
                        textBox7.Enabled = false;
                    }

                    else
                    {
                        textBox7.Enabled = true;
                    }

                    if (textBox8.Enabled == true)
                    {
                        textBox8.Enabled = false;
                    }
                    else
                    {
                        textBox8.Enabled = true;
                    }
                    if (button5.Enabled == true)
                    {
                        button5.Enabled = false;
                        button6.Enabled = true;
                    }
                    else
                    {
                        button5.Enabled = true;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            else
            {
                //do something if NO
            }




        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                if (button6.Enabled == true)
                {
                    button6.Enabled = false;
                    button5.Enabled = true;

                    textBox6.Enabled = true;
                    textBox7.Enabled = true;
                    textBox8.Enabled = true;

                }
                else
                {
                    button6.Enabled = true;
                }
            }

            else
            {
                //do something if NO
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            var variable = "<!--:Begin:Chksum:1:--><!--:Begin:Msg:6:0:--><sample><ver>1.1</ver><instrinfo><p><n>PRDI</n><v>BM850</v></p><p><n>FIWV</n><v>r23206 branches/rel-2.3.6</v></p><p><n>SNO</n><v>116934</v></p><p><n>BRND</n><v>M</v></p><p><n>IAPL</n><v>B</v></p><p><n>IID</n><v>116934</v></p><p><n>LMOF</n><v>33</v></p><p><n>PMPM</n><v>24</v></p><p><n>MBTY</n><v>1</v></p><p><n>HFME</n><v>1</v></p></instrinfo><smpinfo><p><n>ID</n><v>DFGYTR</v></p><p><n>SEQ</n><v>10</v></p><p><n>DATE</n><v>2021-10-21T18:12:23</v></p><p><n>OPID</n></p><p><n>APNA</n><v>Blood</v></p><p><n>ASPM</n><v>OT</v></p><p><n>ASPS</n><v>1</v></p><p><n>SORC</n><v>0</v></p><p><n>BLMD</n><v>0</v></p><p><n>BLNK</n><v>0</v></p><p><n>STYP</n><v>0</v></p><p><n>NOTE</n></p><p><n>RDLI</n><v>2107-539</v></p><p><n>RDPN</n><v>1363</v></p><p><n>RDED</n><v>2024-07-06</v></p><p><n>RLLI</n><v>2103-484</v></p><p><n>RLPN</n><v>790</v></p><p><n>RLED</n><v>2024-03-01</v></p><p><n>RPD</n><v>30</v></p><p><n>RPDS</n><v>1</v></p><p><n>RPDL</n><v>15</v></p><p><n>RPDH</n><v>30</v></p><p><n>RPDF</n><v>27</v></p><p><n>MBTE</n><v>31.0</v></p><p><n>WDDM</n><v>0</v></p><p><n>WDDP</n><v>45</v></p><p><n>WDMS</n><v>1</v></p><p><n>WDMA</n><v>1</v></p><p><n>WDFB</n><v>1</v></p><p><n>WDLL</n><v>40</v></p><p><n>WDLH</n><v>400</v></p><p><n>WDCL</n><v>134</v></p><p><n>WDCH</n><v>150</v></p><p><n>WLGL</n><v>160</v></p><p><n>WDIL</n><v>115</v></p><p><n>WDIH</n><v>165</v></p><p><n>WDOM</n><v>0</v></p><p><n>WDWD</n><v>3</v></p><p><n>CAPL</n></p><p><n>CLVL</n></p><p><n>CEXP</n></p><p><n>CEXT</n></p><p><n>EXCL</n><v>0</v></p><p><n>ASWP</n></p><p><n>ID2</n></p><p><n>PXEN</n><v>2</v></p><p><n>PXCO</n><v>0</v></p><p><n>REGA</n><v>206</v></p><p><n>REOF</n><v>137</v></p><p><n>WHGA</n><v>186</v></p><p><n>WHOF</n><v>218</v></p><p><n>HBGA</n><v>14</v></p><p><n>FITE</n><v>25.3</v></p><p><n>EXTE</n><v>0.0</v></p></smpinfo><smpresults><p><n>RBC</n><v>4.89</v><l>3.50</l><h>5.50</h><el></el><eh></eh></p><p><n>MCV</n><v>90.4</v><l>75.0</l><h>100.0</h><el></el><eh></eh></p><p><n>HCT</n><v>44.2</v><l>35.0</l><h>55.0</h><el></el><eh></eh></p><p><n>MCH</n><v>31.9</v><l>25.0</l><h>35.0</h><el></el><eh></eh></p><p><n>MCHC</n><v>35.2</v><l>31.0</l><h>38.0</h><el></el><eh></eh></p><p><n>RDWR</n><v>11.2</v><l>11.0</l><h>16.0</h><el></el><eh></eh></p><p><n>RDWA</n><v>60.0</v><l>0.1</l><h>250.0</h><el></el><eh></eh></p><p><n>PLT</n><v>227</v><l>130</l><h>400</h><el></el><eh></eh></p><p><n>MPV</n><v>7.1</v><l>5.5</l><h>11.0</h><el></el><eh></eh></p><p><n>PCT</n><v>0.16</v><l>0.01</l><h>9.99</h><el></el><eh></eh></p><p><n>PDW</n><v>10.0</v><l>0.1</l><h>30.0</h><el></el><eh></eh></p><p><n>PDWR</n><v>39.4</v><l>0.1</l><h>99.9</h><el></el><eh></eh></p><p><n>LPCR</n><v>8.6</v><l>0.1</l><h>99.9</h><el></el><eh></eh></p><p><n>LPCA</n><v>19</v><l>1</l><h>1999</h><el></el><eh></eh></p><p><n>HGB</n><v>15.6</v><l>11.5</l><h>16.5</h><el></el><eh></eh></p><p><n>WBC</n><v>9.8</v><l>3.5</l><h>10.0</h><el></el><eh></eh></p><p><n>LA</n><v>2.8</v><l>0.9</l><h>5.0</h><el></el><eh></eh></p><p><n>MA</n><v>0.5</v><l>0.1</l><h>1.5</h><el></el><eh></eh></p><p><n>GA</n><v>6.5</v><l>1.2</l><h>8.0</h><el></el><eh></eh></p><p><n>LR</n><v>28.3</v><l>15.0</l><h>50.0</h><el></el><eh></eh></p><p><n>MR</n><v>5.4</v><l>2.0</l><h>15.0</h><el></el><eh></eh></p><p><n>GR</n><v>66.3</v><l>35.0</l><h>80.0</h><el></el><eh></eh></p></smpresults><tparams><p><n>RCT</n><v>15249</v></p><p><n>WCT</n><v>10329</v></p><p><n>aspt</n><v>1394</v></p><p><n>rdmx</n><v>17</v></p><p><n>rdmn</n><v>415</v></p><p><n>rdbl</n><v>2048</v></p><p><n>rrmn</n><v>1745</v></p><p><n>rrmx</n><v>2188</v></p><p><n>rrmd</n><v>1990</v></p><p><n>rrdp</n><v>843</v></p><p><n>rpds</n><v>147</v></p><p><n>rpdt</n><v>1217</v></p><p><n>rpdd</n><v>152</v></p><p><n>rpus</n><v>1098</v></p><p><n>rpua</n><v>15249</v></p><p><n>rput</n><v>16348</v></p><p><n>rpud</n><v>762</v></p><p><n>rbrn</n><v>0</v></p><p><n>rpdb</n><v>0</v></p><p><n>rpdp</n><v>0</v></p><p><n>rpdo</n><v>0</v></p><p><n>rpub</n><v>0</v></p><p><n>rpup</n><v>0</v></p><p><n>rpu1</n><v>0</v></p><p><n>rpu2</n><v>0</v></p><p><n>rpuu</n><v>0</v></p><p><n>wdmx</n><v>6</v></p><p><n>wdmn</n><v>761</v></p><p><n>wdbl</n><v>1024</v></p><p><n>wrmn</n><v>550</v></p><p><n>wrmx</n><v>672</v></p><p><n>wrmd</n><v>619</v></p><p><n>wrdp</n><v>863</v></p><p><n>wpds</n><v>96</v></p><p><n>wpdt</n><v>726</v></p><p><n>wpdd</n><v>72</v></p><p><n>wpus</n><v>1529</v></p><p><n>wpua</n><v>10329</v></p><p><n>wput</n><v>11859</v></p><p><n>wpud</n><v>344</v></p><p><n>wbrn</n><v>0</v></p><p><n>wpdb</n><v>0</v></p><p><n>wpdp</n><v>0</v></p><p><n>wpdo</n><v>0</v></p><p><n>wpub</n><v>0</v></p><p><n>wpup</n><v>0</v></p><p><n>wpu1</n><v>0</v></p><p><n>wpu2</n><v>0</v></p><p><n>wpuu</n><v>0</v></p><p><n>xdmx</n></p><p><n>xdmn</n></p><p><n>xdbl</n></p><p><n>xrmn</n></p><p><n>xrmx</n></p><p><n>xrmd</n></p><p><n>xrdp</n></p><p><n>xpua</n></p><p><n>xfrt</n><v>2543</v></p><p><n>dpds</n><v>143</v></p><p><n>dpdt</n><v>3204</v></p><p><n>dpus</n><v>1</v></p><p><n>dput</n><v>2846</v></p><p><n>ipds</n><v>183</v></p><p><n>ipdt</n><v>4173</v></p><p><n>ipus</n><v>166</v></p><p><n>iput</n><v>4068</v></p><p><n>lpds</n><v>162</v></p><p><n>lpdt</n><v>3803</v></p><p><n>lpus</n><v>206</v></p><p><n>lput</n><v>5636</v></p><p><n>opds</n></p><p><n>opdt</n></p><p><n>opus</n></p><p><n>oput</n></p><p><n>east</n></p><p><n>exft</n></p><p><n>hbft</n><v>1931</v></p><p><n>pmpw</n><v>265</v></p><p><n>wmpw</n><v>0</v></p><p><n>dpdb</n><v>0</v></p><p><n>dpdp</n><v>0</v></p><p><n>dpdo</n><v>0</v></p><p><n>dpup</n><v>0</v></p><p><n>dpuo</n><v>0</v></p><p><n>dpuf</n><v>0</v></p><p><n>ipdb</n><v>0</v></p><p><n>ipdp</n><v>0</v></p><p><n>ipdo</n><v>0</v></p><p><n>ipup</n><v>0</v></p><p><n>ipuo</n><v>0</v></p><p><n>ipuf</n><v>0</v></p><p><n>lpdb</n><v>0</v></p><p><n>lpdp</n><v>0</v></p><p><n>lpdo</n><v>0</v></p><p><n>lpup</n><v>0</v></p><p><n>lpuo</n><v>0</v></p><p><n>opdb</n><v>0</v></p><p><n>opdp</n><v>0</v></p><p><n>opdo</n><v>0</v></p><p><n>opup</n><v>0</v></p><p><n>opuo</n><v>0</v></p><p><n>asl1</n><v>0</v></p><p><n>asl2</n><v>0</v></p><p><n>acps</n><v>0</v></p><p><n>hbfo</n><v>0</v></p><p><n>nvx1</n><v>0</v></p><p><n>nvx2</n><v>0</v></p><p><n>nvx3</n><v>0</v></p><p><n>nvx4</n><v>0</v></p><p><n>xp1</n><v>0</v></p><p><n>xp2</n><v>0</v></p><p><n>xp3</n><v>0</v></p><p><n>xp4</n><v>0</v></p></tparams><hgrams><hgram><n>PLT</n><m>30</m><k>80</k><w>7</w><d>65</d><hgdata><v>0 0 0 0 2 4 7 11 15 21 26 30 32 34 35 3432 30 27 24 22 19 17 14 13 11 10 9 8 8 7 65 5 4 3 3 2 2 2 2 2 2 2 2 1 1 11 1 1 1 1 1 0 0 0 0 0 0 0 0 0 00 0 0 0 0 0 0 0 0 0 0 0 0 1 1 1</v></hgdata></hgram><hgram><n>RBC</n><m>250</m><k>80</k><w>2</w><d>10</d><hgdata><v>2 20 42 37 19 8 4 2 1 1 0 0 1 1 2 614 34 66 111 161 205 240 254 248 239 225 198 167 142 123 10590 80 74 71 67 65 64 62 56 51 47 42 37 33 29 2419 15 12 11 10 8 7 5 4 4 4 3 3 3 3 21 1 1 1 1 1 1 1 0 0 0 0 0 0 0 0</v></hgdata></hgram><hgram><n>WBC</n><m>450</m><k>80</k><w>4</w><d>8</d><hgdata><n>LYM</n><v>0 0 0 1 2 3 4 5 6 7 8 12 17 22 27 3234 33 30 26 21 16 13 10 8 6 6 5 5 4 3 21 1 0 0 0 0 0 0 0 0 0 0 0 0 0 00 0 0 0 0 0 0 0 0 0 0 0 0 0 0 00 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0</v></hgdata><hgdata><n>MID</n><v>0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 00 0 1 2 3 4 6 6 6 6 5 4 3 2 1 00 0 0 0 0 0 0 0 0 0 0 0 0 0 0 00 0 0 0 0 0 0 0 0 0 0 0 0 0 0 00 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0</v></hgdata><hgdata><n>GRA</n><v>0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 00 0 0 1 1 2 2 3 3 5 7 10 15 20 25 2932 35 38 39 39 37 35 33 31 29 28 26 25 24 23 2222 21 19 17 15 13 12 11 10 9 8 6 5 4 3 22 1 1 1 0 0 0 0 0 0 0 0 0 0 0 0</v></hgdata></hgram></hgrams><rawdata><ccf>+0.0</ccf><rawred><cf><n>RBC</n><v>-5.0</v></cf><cf><n>MCV</n><v>+3.9</v></cf><cf><n>PLT</n><v>-5.2</v></cf><cf><n>MPV</n><v>-18.5</v></cf><cf><n>RDWR</n><v>6325</v></cf><cf><n>RDWA</n><v>6800</v></cf><cf><n>PDW</n><v>7300</v></cf><cf><n>PDWR</n><v>3400</v></cf><rawv><n>RRAV</n><m>400</m><b>4080</b><c>250</c><k>4096</k><cte>B</cte><ccp>D</ccp><v>xxEQALPNCAZbDG306YNUMXVzj39gkwG7Yd5fG3WDwgFP+xMw7+T+HCwksFsxCjDvEYJF4CH+Prp6dEdl6VAIrOgOngA0g5VfrE85ZfkHg5cHTwZCCH7FAQ44QnhiMDoAAWPAJ0+TKQwgIgENKT0QxEAtO4HqfHFxoAWnziKOBlKSBYE48LAgzw4JnBYEEGzx8uRLgTfIdIe8E4f4h8DsRD0DuXIA1Oh0I+CnBqan8HCXrYg0n5dkEoNyANv/Ud0nCID62DWa7+MUFdPi4AJOv4aKwRiPvZh2NvqsoLrrYHbATAb6ZdCEFdfCega2nXvo4hdIgQ3Hqmwn15RBX3nJeHIaP/BfBnfaFxvmYZPow1/53BPfRvQOw6PWphWpVYZnAJu/RthvhPPxnuAx/nvnPpP90BKQjeA+X4R6jXA6mOf7V6iy8Ut8iC7gfuUjNxqVNvyhruQhex8fFulbeFehOdQD+hLjQ8wTORRF5wcvlMNi/V9dh/uDxPakdfDBR/8i61r4CcWdwP3YyJbdVovz+BASXVnux1bzrPQOhOAmblgXkBNrSfb8Q9lBLA7DuQfuQxRsEf+/w+/E4CxFvbDMepP+Ea4Ah56wzh98uClKKQPE2m5riTxkSXJgcDSgL2B69x1uHECgle7teF6B4BQU/A0MICOzVTe8BgM3J7aO+CnQ8DHlYeXPdwUQO/4IDkMrUgPY+yAkg8QoMhHUhiBovATa/g4rGEQvcE6T3i7NzQoGhAVNlALJ+9CmoDAJsIrpBZP9p3k4hogeEBDHV8Bn9Jc/gJdgrgVAdPxGsQRAugzLYCSaYDbBw+CiIKzLwH3LNQ6Ystd74JuLwExfvCkIvwQOx/oJI+dNgf/g+E1glxAX//XyOQ71DHn4Jmff/8HlwHcPNP26lTrGCTM/e8R75wfq0eICO+I6La034j8EiAbbBBCET3AaTAeTwlODjMoLBPh8QPsogPAlNwCXbj5AZEHjquiFsvB+GP5MD4P4ugF35bwFWoub9CxUC4BK2+j/gbrMeLQeCtAU4y0sE8br/3kx64JWii8HZC4gJ93vgiHFeu2B2AgZqh5hgFpcaX4An6tQSYDK34pUAR3uSed0B8h+hBef8APfBYDjkX9I1ewkwHB31oh8tId9ID7FdfnhmDSwGIA5NCw0FvwQSyDy/jGyAi7ubA8RHS/lwS/S5eAP4vBsFLjAgAMgh6CuMV+AseEHBuA6HI5OCqOPHLvRp8FdAu4UzyHQPkyA6xA4B6HHBWBwJGD+Y+B4J4HRqBwPAP7p555IHAAHPWAQxAHI64IwI4XA6KnJgdQGniwcBc4EckYKeaUQxTI67QdXCoJx4WCxI4ABGnqhEogWdJx6zqwWPWnmoQEFj1PLK0AWnjAigsDyAerPDiMFp4UozgvwAAFllpP747SiILE6eFPgLHuz4JJTR1oAIOnfkzgtO8FqgU1DqPyYCAOnngABadyDOC04dD6uHIGn9cIEhodV84gtODQ6pBaVXmgQ2r1dqHzQESC0sXU+n1Lw7C5xrNcp0hpuHcR3gN22sDUnG3E64DXIa6PWNrC1TqzW1r5n14FqrpDQ842prn9REiFXKg==</v></rawv><rawv><n>RRRV</n><m>400</m><b>4080</b><c>250</c><k>4096</k><cte>B</cte><ccp>D</ccp><v>xyEQALDSCyugCOLZwB73G/de9mTF3QCx6K5p/hc8FeAgC37Dna3059Q6evKf/JnMFP3nRD3+QgMii4FwSrwEhatAwHVptD1wiwvIOOCxARPG3Hws8vS4BEDIAjwcXUxMgM1jiFzrBX/E79MMf4B4RPE7j7kyAY+T34/eLEGz888gLUyAIIq5HA6XxXx6w75xf9IIPAyW4QyOKmBc84gAgP9QbP+Lz1c4uIA9IChYA5AY+CuQCwBAwXEFM8iHB4fARA6BCsBHxHkgLlgGeP1gMlBxIAD9fknZD8k/IA88L9wcPS0uFM8VgNuhkR/UuphPxL9H17UgNyrySCP8yKzhYK+PJfJAZXIAJ+hehHwU+4B4dB0Kr2EnEBQt4PTiw0vy9b/y4EgL3/1wvYKDoH4//LcAj+HQFlVWAoNwCfFS/zw8F7EMjCkAOcvggB1ByAR/HTqrpAI/MFb5IDj4h/hTk4rkYHuX/ycRzgAVgC9xwetwQRwFgeseAAOAssQThyDiOFwDgEaeEOsARz+SMhiR+Tp4QdgjTwVj+EoONZf/lxeB5ABY8nHgjgBZcd/EHHiCmR4QaA6sSBgACtycR1geQOsHQsQHsAEOAcAAFPDsMFgRyefwsF1j+tPCUcFzgesAAv2N1jz1ziAHeehgsDBSAvPHQxHenhHmCGAJ5xfGOC4Ix74yyOVngOcFln+eeDzkMnIwdeAHCO5PIHIwX6O5AA8FYCjhccjjrQUjAgFQFTyAFhwv1wAeAOshljwVwfkBzzgx1OrsFgRzwSDTyOFiOeuuDSAuMCf0OcQfweV+COB1lxwEOfweeFgesFj1PF9/PgenmojQFgARwgNPNqpgLAA8EdCeGRdB4aYAsRz1p6YiDALT5BBbIDWAstOJp+kALEDgABY8BaeADZ/LIQAQnjysAtPGEDpgWnpkEM0fhoDRgtJ9QdIbA5TR6l42g42h+DIEBmabh13vgcIm0OpvhSAgoDV6g5xq9YfighoOW1Or9S6j1xmpdbupta/WDaOtjUGpdcvruNUay9ex65XWvymx9W6k1n66zXAaxdcF4IFrdcHrkNZGvi7VmuiJcJfK</v></rawv><p><n>RREJ</n><v>3</v></p><p><n>RRBR</n><v>1</v></p><ccompr><ccctr>60996000</ccctr><ccwra>5747468</ccwra><ccwrr>548632</ccwrr><ccwpa>105217</ccwpa><ccwpr>427735</ccwpr><ccnra>29014</ccnra><ccnrr>2152</ccnrr><ccnpa>1145</ccnpa><ccnpr>2124</ccnpr><cctrr>250</cctrr><ccbtr>20</ccbtr><ccbtp>20</ccbtp></ccompr><mcvtc><a>4095</a><mtctype>0</mtctype><mtcv>3216</mtcv><mtci>3200</mtci><mtct>1393</mtct><mtcr>2880</mtcr><mtcq>3216</mtcq><mtcve>3216</mtcve><mtcie>3120</mtcie><mtcte>1393</mtcte><mtcre>2880</mtcre><mtcqe>3216</mtcqe></mcvtc></rawred><rawwht><cf><n>WBC</n><v>-9.1</v></cf><rawv><n>RWAV</n><m>800</m><b>4080</b><c>420</c><k>4096</k><cte>B</cte><ccp>D</ccp><v>xzEQALxzCXAXp3+P+kAN+gDxwFueQ/gAAOYKZADlUAHnlUAAHnrjg8n8reCmRgX4I4DoKHzx/Cy44BP4eBnlyaYL9jd4BUn8g4BOrfwVyOPFIwP8kqjAv8wcTT7xIdIsLkgKMXuTg7BTHkk8cLPIgEMPmrSW0xv4AAf2CRiAoH8AiXjgJg+vaR4nJjaXnBXgJaSYuANCsAMA8SeroKcdvgBjyI+vcsFeAodpvFyURAtCmgeA3br0QgAcnENgQ35EVAnj/Jo6nkXZAA91Ede6CgLXmOQHf7G9Lg4QL/gI9x2Iillplp34JAYE8cEKDjXAA9cfo8GceK6f+Hpglid6dwiHAm8gag+VB60sB+Of2DjuljQrBTjwi8PPP8zwQ8PSA9Y4HIHEFaA9bB/1sObVn0DjG4Anr9/rWCvf6dq4IJgMH9p78EiA5AA08nDk95zChef6Vpq6A6RhphZAf6WG0BtskAd7CIEPTZAFV4CIeC0XGGLKGGGPD4X6EH81HpetGYWPLifqaC2Wjx9BKtASL9MMHkDxTB5fwRLeIf8VtLP/gkYgKdh6RBy2XNueUEqAz9r4hy5pB4nXtwJAYH1/FCEXPum6iA/f+vn+AYdiJiV6ePFUEj3+JvASH0O9M9AcAisAPxDltfDi0ioS4CEcQ5Pv9QgsQFeItM+OT1t0gwIJEBo9LvTPTW4aE/QKIGosPktq5NBux90IJUBrQEP9rEPMeL+1aXuYLTD1r4k7Txe0hLdWAGXWpXZcGh485OLWgsQFfIRvj7ySy4eTS/QeyH8Eh5NAv8eAF/gBO4vAP/l7SBB7ytBDFSf4CA9eYDB/oCsc//v/t3LguDnAngXcTwWICWhzY9RhSAxWPOS+8FIDZAHg19f8kekKDhAnhpeA6gD+gJ4CWAl5cWgEEiAzAcdHj8mCsxgXfHW570FLT+LQT+EtTeAvLIBYnhY8QXkAPFwD7xBaHkgMADl8wpgWePD+cHIBHg0hcYgE8/LQU0fAh0TyAeI5q7wy73C3gtukJbxB6aHgPgmQHX4RFXAHAC4OfNABBxBO6cwPAHjpUOjgHgQUwFuABOngSYEPwAhxyeCccDweAFzgRyOFzgD3+OCdPGKYBYLT4YSVA1aD6dQE0ogKBn9sBAYAWnQGm88pBarrBpPDIG4HWBrgNcXryrWfr0HXL6+N9fJOv0JBwPIgAA==</v></rawv><p><n>RWEJ</n><v>0</v></p><p><n>RWBR</n><v>5</v></p><ccompw><ccctw>41316000</ccctw><ccwwa>638214</ccwwa><ccwwr>2557</ccwwr><ccnwa>6340</ccnwa><ccnwr>8</ccnwr><cctrw>250</cctrw><ccbtw>20</ccbtw></ccompw></rawwht><rawrxc><p><n>RXEJ</n><v>0</v></p><p><n>RXBR</n><v>0</v></p><ccompx><ccctx>0</ccctx><ccwxa>0</ccwxa><ccwxr>0</ccwxr><ccwqa>0</ccwqa><ccwqr>0</ccwqr><ccnxa>0</ccnxa><ccnxr>0</ccnxr><ccnqa>0</ccnqa><ccnqr>0</ccnqr></ccompx></rawrxc><rawhgb><cf><n>HGB</n><v>-17.4</v></cf><a>4095</a><rdp><n>HDRK</n><sl>10</sl><sh>4</sh><k>30</k><v>148 148 148 148 148 148 148 148 148 148 148 148 147 148 148147 148 148 148 148 148 148 148 148 148 148 148 148 148 148</v></rdp><rdp><n>HBLN</n><sl>10</sl><sh>4</sh><k>30</k><v>3497 3497 3498 3497 3497 3497 3497 3497 3497 3497 3497 3497 3497 3497 34973497 3497 3497 3497 3497 3497 3497 3497 3497 3497 3497 3498 3497 3497 3498</v></rdp><rdp><n>HSMP</n><sl>10</sl><sh>4</sh><k>30</k><v>1557 1556 1557 1557 1557 1557 1557 1557 1557 1557 1557 1558 1557 1558 15571558 1558 1558 1558 1558 1558 1558 1558 1558 1559 1559 1559 1559 1559 1559</v></rdp></rawhgb></rawdata></sample><!--:End:Msg:6:0:--><!--:End:Chksum:1:70:90:-->";


            //var Temp = Parse_Xml(textBox4.Text);


            var Temp = Parse_Xml(variable);

            Veri_Tabanına_Yaz_(variable);
            //XmlSerializer serializer = new XmlSerializer(typeof(sample));
            //using (StringReader reader = new StringReader(Xml))
            //{
            //    var test = (sample)serializer.Deserialize(reader);
            //}
            //textBox1.Text += "asdasdasd";


            var Tablo = (from Data in Temp.smpresults.p
                         select new
                         {
                             Data.n,
                             Data.v
                         });




            IList<Tam_Kan_Tablo> Gönderilecek = Tablo.Select(o => new Tam_Kan_Tablo
            {
                Değer = o.v,
                Değer_Adı = o.n
            }).ToList();


            var Grafik_Tablo = (from Data in Temp.smpresults.p
                                select new
                                {
                                    Data.n,
                                    Data.v
                                });


            IList<Tam_Kan_Tablo> Gönderilecek_Grafik = Grafik_Tablo.Select(o => new Tam_Kan_Tablo
            {
                Değer = o.v,
                Değer_Adı = o.n
            }).ToList();


            Tam_Kan_Tablo X_1 = new Tam_Kan_Tablo
            {
                Değer_Adı = "PLT_Grafik",
                Değer = (Temp.hgrams.hgram.FirstOrDefault(o => o.n == "PLT").hgdata.First().v)
            };
            Gönderilecek_Grafik.Add(X_1);

            Tam_Kan_Tablo X_2 = new Tam_Kan_Tablo
            {
                Değer_Adı = "RBC_Grafik",
                Değer = (Temp.hgrams.hgram.FirstOrDefault(o => o.n == "RBC").hgdata.First().v)
            };
            Gönderilecek_Grafik.Add(X_2);


            Tam_Kan_Tablo X_3 = new Tam_Kan_Tablo
            {
                Değer_Adı = "WBC_LYM",
                Değer = (Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.First().v)
            };
            Gönderilecek_Grafik.Add(X_3);

            Tam_Kan_Tablo X_4 = new Tam_Kan_Tablo
            {
                Değer_Adı = "WBC_MID",
                Değer = (Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.First().v)
            };
            Gönderilecek_Grafik.Add(X_4);

            Tam_Kan_Tablo X_5 = new Tam_Kan_Tablo
            {
                Değer_Adı = "WBC_GRA",
                Değer = (Temp.hgrams.hgram.FirstOrDefault(o => o.n == "WBC").hgdata.First().v)
            };
            Gönderilecek_Grafik.Add(X_5);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = Convert.ToInt32(textBox2.Text);
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
            serialPort1.DataBits = Convert.ToInt32(textBox3.Text);
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;
            
                

            serialPort1.Open();
        }
    }
   
}

