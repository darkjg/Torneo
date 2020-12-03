using FileHelpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TorneoVisual
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        string query;
        MySqlCommand commandDatabase;
        MySqlDataReader reader;
        public string connectionString = "";
        MySqlConnection databaseConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                databaseConnection = new MySqlConnection(connectionString);
                databaseConnection.Open();
                query = "SELECT * FROM `jugadores` WHERE 1";
                commandDatabase = new MySqlCommand(query, databaseConnection);
                databaseConnection.Close();
            }
            catch (MySqlException ex)
            {
                connectionString = "";
            }
            cargar();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int altura = ((Form1.ActiveForm.Height) / 17) - 1;
            int altura2 = (altura * 2) + 1;
            int altura3 = altura2 * 2;
            int altura4 = (altura3 * 2) + 30;
            Console.WriteLine("Altura entre 17" + altura);
            List<Control> c = Controls.OfType<ComboBox>().Cast<Control>().ToList();
            ComboBox[] combos = new ComboBox[c.Count];
            ComboBox[] combosord = new ComboBox[c.Count];
            int icontrol = 0;
            foreach (var control in c)
            {
                combos[icontrol] = (ComboBox)control;
                // Console.WriteLine(combos[icontrol].Name);
                icontrol++;
            }
            Comparison<ComboBox> comparador = new Comparison<ComboBox>((numero1, numero2) => numero1.Name.CompareTo(numero2.Name));
            Array.Sort<ComboBox>(combos, comparador);
            menuStrip1.Location = new Point(0, 0);
            comboBox1.Location = new Point(10, 35);
            Console.WriteLine("Posicion 17 x " + comboBox17.Location.X);
            comboBox17.Location = new Point(Form1.ActiveForm.Size.Width - comboBox17.Width - 25, 35);
            comboBox41.Location = new Point(comboBox17.Location.X - comboBox17.Width - 20, 65);
            comboBox53.Location = new Point(comboBox41.Location.X - comboBox41.Width - 20, 115);
            for (int icomparador = 0; icomparador < combos.Length; icomparador++)
            {
                for (int i = 0; i < combosord.Length; i++)
                {
                    if (combos[i].Name.Equals("comboBox" + (icomparador + 1)))
                    {
                        //Console.WriteLine(combos[icomparador].Name.Equals("comboBox" + (iord)));
                        //Console.WriteLine(combos[icomparador].Name);
                        combosord[icomparador] = combos[i];
                    }
                }
            }

            for (int i = 1; i < 16; i++)
            {
                Console.WriteLine(i + "  " + combosord[i - 1].Location.Y);

                //   combosord[i].SelectedText = combos[i].Name;
                combosord[i].Location = new Point(comboBox1.Location.X, combosord[i - 1].Location.Y + altura);
            }

            for (int i = 17; i < 32; i++)
            {
                //   combosord[i].SelectedText = combosord[i].Name;
                //console.WriteLine(combos[i - 1].Name);
                combosord[i].Location = new Point(comboBox17.Location.X, combosord[i - 1].Location.Y + altura);
            }
            for (int i = 33; i < 40; i++)
            {
                //   combosord[i].SelectedText = combosord[i].Name;
                Console.WriteLine(altura2);
                combosord[i].Location = new Point(comboBox33.Location.X, combosord[i - 1].Location.Y + altura2);
            }
            for (int i = 41; i < 48; i++)
            {
                //   combosord[i].SelectedText = combosord[i].Name;
                //console.WriteLine(combos[i - 1].Name);
                combosord[i].Location = new Point(comboBox41.Location.X, combosord[i - 1].Location.Y + altura2);
            }
            for (int i = 49; i < 52; i++)
            {
                //   combosord[i].SelectedText = combosord[i].Name;
                Console.WriteLine(altura2);
                combosord[i].Location = new Point(comboBox49.Location.X, combosord[i - 1].Location.Y + altura3);
            }
            for (int i = 53; i < 56; i++)
            {
                //   combosord[i].SelectedText = combosord[i].Name;
                //console.WriteLine(combos[i - 1].Name);
                combosord[i].Location = new Point(comboBox53.Location.X, combosord[i - 1].Location.Y + altura3);
            }
            comboBox57.Location = new Point(comboBox57.Location.X, comboBox4.Location.Y);
            comboBox58.Location = new Point(comboBox58.Location.X, comboBox12.Location.Y);
            comboBox59.Location = new Point(comboBox53.Location.X - comboBox53.Width - 20, comboBox4.Location.Y);
            comboBox60.Location = new Point(comboBox59.Location.X, comboBox12.Location.Y);
            comboBox61.Location = new Point((Form1.ActiveForm.Width / 2) - (comboBox61.Width * 2), comboBox8.Location.Y);
            comboBox62.Location = new Point((Form1.ActiveForm.Width / 2) + comboBox62.Width, comboBox8.Location.Y);
            int medio = (Form1.ActiveForm.Width / 2) - (comboBox61.Width / 2);
            comboBox63.Location = new Point(medio, comboBox62.Location.Y - (comboBox63.Height * 5));
            //comboBox63.Text = "3";
            comboBox64.Location = new Point(medio, comboBox62.Location.Y + (comboBox63.Height * 5));
            //comboBox64.Text = "4";
            label1.Location = new Point(comboBox63.Location.X + (comboBox63.Width / 2), comboBox63.Location.Y - comboBox63.Height);
            label2.Location = new Point(comboBox61.Location.X + (comboBox61.Width / 2), comboBox61.Location.Y - comboBox61.Height);
            label3.Location = new Point(comboBox62.Location.X + (comboBox62.Width / 2), comboBox62.Location.Y - comboBox62.Height);
            label4.Location = new Point(comboBox64.Location.X + (comboBox64.Width / 2), comboBox64.Location.Y - comboBox64.Height);
        }



        private void Form1_Click(object sender, EventArgs e)
        {

        }
        private static void Ejecutarbasededatos(string query, MySqlConnection databaseConnection)
        {

            try
            {
                MySqlCommand commandDatabase;
                MySqlDataReader reader;
                // Abre la base de datos
                databaseConnection.Open();
                commandDatabase = new MySqlCommand(query, databaseConnection);
                // Ejecuta la consultas
                reader = commandDatabase.ExecuteReader();
                // Cerrar la conexión
                databaseConnection.Close();
                Console.WriteLine("Ejecutado satisfactoriamente");
            }
            catch (Exception ex)
            {

                // Mostrar cualquier excepción
                Console.WriteLine(ex.Message + " HOLAAAA");
            }
        }
        private static string DevolverQuery(string query, MySqlConnection databaseConnection)
        {
            MySqlCommand commandDatabase;
            MySqlDataReader reader;
            string devolver = "";
            try
            {
                // Abre la base de datos
                databaseConnection.Open();
                commandDatabase = new MySqlCommand(query, databaseConnection);
                // Ejecuta la consultas
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    devolver = reader[0].ToString();
                }

                // Cerrar la conexión
                databaseConnection.Close();
                //  Console.WriteLine("Ejecutado satisfactoriamente");
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                Console.WriteLine(ex.Message + "AQui");

            }
            return devolver;
        }

        private void comboBox33_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox49.Items.Add(comboBox33.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox33.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);


        }

        private void comboBox34_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox49.Items.Add(comboBox34.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox34.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox35_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox50.Items.Add(comboBox35.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox35.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox36_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox50.Items.Add(comboBox36.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox36.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox37_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox51.Items.Add(comboBox37.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox37.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox38_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox51.Items.Add(comboBox38.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox38.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }
        private void comboBox39_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox52.Items.Add(comboBox39.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox39.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }
        private void comboBox40_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox52.Items.Add(comboBox40.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox40.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }
        private void comboBox41_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox53.Items.Add(comboBox41.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox41.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox42_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox53.Items.Add(comboBox42.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox42.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox43_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox54.Items.Add(comboBox43.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox43.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }
        private void comboBox44_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox54.Items.Add(comboBox44.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox44.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }
        private void comboBox45_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox55.Items.Add(comboBox45.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox45.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }
        private void comboBox46_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox55.Items.Add(comboBox46.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox46.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }
        private void comboBox47_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox56.Items.Add(comboBox47.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox47.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }
        private void comboBox48_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox56.Items.Add(comboBox48.Text);
            string query = " UPDATE posiciones SET posicion16 = ((SELECT  ifnull (posicion16,0) FROM posiciones ORDER BY posicion16 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + comboBox48.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox50_SelectedValueChanged_1(object sender, EventArgs e)
        {
            ComboBox aux = (ComboBox)sender;
            comboBox57.Items.Add(aux.Text);
            string query = " UPDATE posiciones SET posicion8 = ((SELECT  ifnull (posicion8,0) FROM posiciones ORDER BY posicion8 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + aux.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox52_SelectedValueChanged_1(object sender, EventArgs e)
        {
            ComboBox aux = (ComboBox)sender;
            comboBox58.Items.Add(aux.Text);
            string query = " UPDATE posiciones SET posicion8 = ((SELECT  ifnull (posicion8,0) FROM posiciones ORDER BY posicion8 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + aux.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox54_SelectedValueChanged_1(object sender, EventArgs e)
        {
            ComboBox aux = (ComboBox)sender;
            comboBox59.Items.Add(aux.Text);
            string query = " UPDATE posiciones SET posicion8 = ((SELECT  ifnull (posicion8,0) FROM posiciones ORDER BY posicion8 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + aux.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox56_SelectedValueChanged_1(object sender, EventArgs e)
        {
            ComboBox aux = (ComboBox)sender;
            comboBox60.Items.Add(aux.Text);
            string query = " UPDATE posiciones SET posicion8 = ((SELECT  ifnull (posicion8,0) FROM posiciones ORDER BY posicion8 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + aux.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox58_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox aux = (ComboBox)sender;
            comboBox61.Items.Add(aux.Text);
            comboBox62.Items.Add(aux.Text);
            comboBox63.Items.Add(aux.Text);
            comboBox64.Items.Add(aux.Text);
            string query = " UPDATE posiciones SET posicion4 = ((SELECT  ifnull (posicion4,0) FROM posiciones ORDER BY posicion4 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + aux.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox60_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox aux = (ComboBox)sender;
            comboBox61.Items.Add(aux.Text);
            comboBox62.Items.Add(aux.Text);
            comboBox63.Items.Add(aux.Text);
            comboBox64.Items.Add(aux.Text);
            string query = " UPDATE posiciones SET posicion4 = ((SELECT  ifnull (posicion4,0) FROM posiciones ORDER BY posicion4 DESC LIMIT 1)+1)  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + aux.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }



        private void comboBox61_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox aux = (ComboBox)sender;

            string query = " UPDATE posiciones SET posicionfinal = 2  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + aux.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void comboBox62_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox aux = (ComboBox)sender;

            string query = " UPDATE posiciones SET posicionfinal = 3 WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + aux.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }
        private void comboBox63_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox aux = (ComboBox)sender;

            string query = " UPDATE posiciones SET posicionfinal = 1  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + aux.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }
        private void comboBox64_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox aux = (ComboBox)sender;

            string query = " UPDATE posiciones SET posicionfinal =4  WHERE posiciones.Id = (SELECT Id FROM jugadores WHERE jugadores.NombreLol LIKE('" + aux.Text + "'))";
            Ejecutarbasededatos(query, databaseConnection);
        }

        private void cargarJugadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas cargar y randomizar a los jugadores?\n Los resultados anteriores se borraran", "Cargar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string ruta;
                int result;
                OpenFileDialog p = new OpenFileDialog();
                p.Filter = "Archivo csv(.csv)|*.csv";
                p.ShowDialog();
                ruta = p.FileName;
                Console.WriteLine(ruta);
                databaseConnection = new MySqlConnection(connectionString);
                var engine = new FileHelperEngine<CsvForm>();

                try
                {
                    var records = engine.ReadFile(ruta);

                    query = "Truncate table jugadores";
                    Ejecutarbasededatos(query, databaseConnection);
                    Console.WriteLine("Jugadores truncados");
                    foreach (var record in records)
                    {
                        query = "INSERT INTO jugadores(`Id`, `NombreLol`, `NombreTwich`) VALUES (NULL, " + record.Nombre_lol + "," + record.Nombre_Twich + ")";
                        Ejecutarbasededatos(query, databaseConnection);
                        Console.WriteLine(record.Nombre_lol);
                        Console.WriteLine(record.Nombre_Twich);
                        databaseConnection.Close();
                    }
                    RandomizarJugadores();
                    MessageBox.Show("Jugadores cargados y randomizados");
                }
                catch (System.ArgumentException ex)
                {

                }
                databaseConnection.Close();
            }
            else
            {
                MessageBox.Show("Jugadores no cargados");
            }
        }

        private void randomizarJugadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas randomizar a los jugadores?\n Los resultados anteriores se borraran", "Randomizar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RandomizarJugadores();

            }

            else

            {

                MessageBox.Show("Jugadores no randomizados");

            }


        }
        //Metodo que genera numeros aleatorios sin repetir
        private int[] generarNumerosNoRepetidos(int[] array)
        {
            int num;
            for (int i = 0; i < array.Length; i++)
            {
                do
                {
                    num = random.Next(1, array.Length + 1);
                } while (isRepetido(array, num));
                array[i] = num;
            }
            return array;
        }
        private static bool isRepetido(int[] array, int r)
        {
            for (int i = 0; i < array.Length; i++)
                if (r == array[i])
                    return true;
            return false;
        }
        private void cargar()
        {
            try
            {

                int i = 1;
                databaseConnection = new MySqlConnection(connectionString);
                string[] nombres = new string[32];
                List<Control> c = Controls.OfType<ComboBox>().Cast<Control>().ToList();
                ComboBox prueba;
                // databaseConnection = new MySqlConnection(connectionString);
                for (int i2 = 0; i2 < nombres.Length; i2++)
                {
                    query = "SELECT NombreLol FROM jugadores WHERE id =(SELECT id FROM posiciones WHERE posiciones.Posicion32=" + i + ")";
                    //  Console.WriteLine(i2 + DevolverQuery(query, databaseConnection));

                    if (DevolverQuery(query, databaseConnection).Equals("nombre lol"))
                    {
                        i++;
                        i2--;
                    }
                    else
                    {
                        nombres[i2] = DevolverQuery(query, databaseConnection);
                        i++;
                    }
                }
                ComboBox[] combos = new ComboBox[c.Count];
                ComboBox[] combosord = new ComboBox[c.Count];
                int icontrol = 0;
                foreach (var control in c)
                {
                    combos[icontrol] = (ComboBox)control;
                    // Console.WriteLine(combos[icontrol].Name);
                    icontrol++;
                }
                Comparison<ComboBox> comparador = new Comparison<ComboBox>((numero1, numero2) => numero1.Name.CompareTo(numero2.Name));
                Array.Sort<ComboBox>(combos, comparador);
                for (int icomparador = 0; icomparador < combos.Length; icomparador++)
                {
                    for (int i3 = 0; i3 < combosord.Length; i3++)
                    {
                        if (combos[i3].Name.Equals("comboBox" + (icomparador + 1)))
                        {
                            //Console.WriteLine(combos[icomparador].Name.Equals("comboBox" + (iord)));
                            //Console.WriteLine(combos[icomparador].Name);
                            combosord[icomparador] = combos[i3];
                        }
                    }
                }
                int incremento = 0;
                for (int i3 = 0; i3 < 32; i3++)
                {
                    combosord[i3].Text = nombres[i3];
                    combosord[i3].Items.AddRange(nombres);
                }

                for (int i3 = 32; i3 < 48; i3++)
                {
                    Console.WriteLine(incremento);
                    for (int i2 = 0; i2 < 2; i2++)
                    {
                        combosord[i3].Items.Add(combosord[i2 + incremento].Text);
                    }
                    incremento = incremento + 2;
                }

            }

            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                Console.WriteLine(ex.Message);

                databaseConnection.Close();

            }
            databaseConnection.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Torneo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }

        }
        public void RandomizarJugadores()
        {
            int[] participantes;
            int limit = 0;
            databaseConnection = new MySqlConnection(connectionString);
            query = "Truncate table posiciones";
            Ejecutarbasededatos(query, databaseConnection);
            Console.WriteLine("Jugadores truncados");
            query = "select * from jugadores order by Id desc limit 1 ";
            List<Control> c = Controls.OfType<ComboBox>().Cast<Control>().ToList();
            ComboBox[] combos = new ComboBox[c.Count];
            ComboBox[] combosord = new ComboBox[c.Count];
            int icontrol = 0;
            foreach (var control in c)
            {
                combos[icontrol] = (ComboBox)control;
                // Console.WriteLine(combos[icontrol].Name);
                icontrol++;
            }
            Comparison<ComboBox> comparador = new Comparison<ComboBox>((numero1, numero2) => numero1.Name.CompareTo(numero2.Name));
            Array.Sort<ComboBox>(combos, comparador);
            for (int icomparador = 0; icomparador < combos.Length; icomparador++)
            {
                for (int i3 = 0; i3 < combosord.Length; i3++)
                {
                    if (combos[i3].Name.Equals("comboBox" + (icomparador + 1)))
                    {
                        //Console.WriteLine(combos[icomparador].Name.Equals("comboBox" + (iord)));
                        //Console.WriteLine(combos[icomparador].Name);
                        combosord[icomparador] = combos[i3];
                    }
                }
            }
            for (int i3 = 32; i3 < 64; i3++)
            {
                combosord[i3].Items.Clear();
                combosord[i3].Text = "";
            }

            try
            {

                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    limit = reader.GetInt32(0);
                }
                databaseConnection.Close();
                participantes = new int[limit];
                participantes = generarNumerosNoRepetidos(participantes);
                for (int i = 0; i < participantes.Length; i++)
                {
                    query = "INSERT INTO posiciones (Posicion32 ) values( " + participantes[i] + ")";
                    Ejecutarbasededatos(query, databaseConnection);
                    Console.WriteLine(participantes[i]);
                }

            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                Console.WriteLine(ex.Message + "Aqui 1");
            }
            databaseConnection.Close();
            cargar();
            MessageBox.Show("Jugadores randomizados con exito");
        }
    }
}
