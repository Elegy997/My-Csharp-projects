namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        List<Sorsolas> sorsolas_list = new List<Sorsolas>();
        List<Szam> szam_list = new List<Szam>();
        public Form1()
        {
            InitializeComponent();
            //Beolvasás másképp:
            string[] lines = File.ReadAllLines("lotto.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Sorsolas sorsolas_object = new Sorsolas(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                sorsolas_list.Add(sorsolas_object);
            }
            //második feladat
            int darab = 0;
            for (int i = 1; i < 46; i++)
            {
                foreach (var item in sorsolas_list)
                {
                    if(i == item.szam1 || i == item.szam2 || i == item.szam3 || i == item.szam4 || i == item.szam5 || i == item.szam6)
                    {
                        darab++;
                    }
                }
                Szam szam_object = new Szam(i, darab);
                szam_list.Add(szam_object);
                darab = 0;
            }

            int min_db = int.MaxValue;
            int min_db_szam = 0;
            foreach (var item in szam_list)
            {
                if(min_db > item.db)
                {
                    min_db = item.db;
                    min_db_szam = item.szam;
                }
            }
            label2.Text = $"{min_db_szam}: {min_db}";

            //harmadik feladat
            int paratlan_sum =0;
            foreach(var item in szam_list)
            {
                if (item.szam % 2 != 0)
                {
                    paratlan_sum += item.db;
                }
            }
            label3.Text = $"partatlan: {paratlan_sum}";

            //negyedik feladat

            foreach (var item in szam_list)
            {
                if(item.szam == 1)
                {
                    label4.Text = $"egy: {item.db}";
                }
            }

            //otodik feladat

            foreach (var item in szam_list)
            {
                if (item.szam == 3)
                {
                    label5.Text = $"harom: {item.db}";
                }
            }

            //hatodik,hetedik feladat
            foreach (var item in szam_list)
            {
                dataGridView1.Rows.Add(item.szam, item.db);
            }
        }
        //elso feladat
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in sorsolas_list)
            {
                if(numericUpDown1.Value == item.het)
                {
                    label1.Text = $"{item.het}, {item.szam1}, {item.szam2}, {item.szam3}, {item.szam4}, {item.szam5}, {item.szam6}, ";
                }
            }
        }
    }
}