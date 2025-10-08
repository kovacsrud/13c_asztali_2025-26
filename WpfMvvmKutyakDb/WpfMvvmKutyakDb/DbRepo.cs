using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMvvmKutyakDb.Mvvm.Model;
using System.Data.SQLite;

namespace WpfMvvmKutyakDb
{
    public static class DbRepo
    {
        public static List<Kutyanev> GetKutyanevek()
        {
            List<Kutyanev> kutyanevek= new List<Kutyanev>();

            try
            {
                using (SQLiteConnection connection=new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string sqlCommand = "select * from kutyanevek";
                    using (SQLiteCommand command=new SQLiteCommand(sqlCommand,connection))
                    {
                        using (SQLiteDataReader reader=command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Kutyanev kutyanev = new Kutyanev
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    KutyaNev = reader["kutyanev"].ToString()
                                };
                                kutyanevek.Add(kutyanev);
                            }

                        }

                    }

                }
            }
            catch (SQLiteException ex) {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }



            return kutyanevek;
        }

        public static List<Kutyafajta> GetKutyafajtak()
        {
            List<Kutyafajta> kutyafajtak = new List<Kutyafajta>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string sqlCommand = "select * from kutyafajtak";
                    using (SQLiteCommand command = new SQLiteCommand(sqlCommand, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Kutyafajta kutyafajta = new Kutyafajta
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nev = reader["nev"].ToString(),
                                    EredetiNev = reader["eredetinev"].ToString()
                                };
                                kutyafajtak.Add(kutyafajta);
                            }

                        }

                    }

                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            return kutyafajtak;
        }

        public static void UjKutyanev(Kutyanev kutyanev)
        {
            try
            {
                using (SQLiteConnection connection=new SQLiteConnection(Config.connectionString))
                {
                   connection.Open();
                   string insertCommand = "insert into kutyanevek (kutyanev) values(@kutyanev)";
                   using (SQLiteCommand command=new SQLiteCommand(insertCommand,connection))
                   {
                        command.Parameters.AddWithValue("@kutyanev", kutyanev.KutyaNev);
                        var sorok = command.ExecuteNonQuery();
                        MessageBox.Show($"{sorok} sor beszúrva!");
                   }


                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ModositKutyanev(Kutyanev kutyanev)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string updateCommand = "update kutyanevek set kutyanev=@kutyanev where Id=@id";
                    using (SQLiteCommand command=new SQLiteCommand(updateCommand,connection))
                    {
                        command.Parameters.AddWithValue("@kutyanev", kutyanev.KutyaNev);
                        command.Parameters.AddWithValue("@id", kutyanev.Id);
                        var sorok = command.ExecuteNonQuery();
                        MessageBox.Show($"{sorok} sor módosítva!");
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void TorolKutyanev(Kutyanev kutyanev)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string deleteCommand = "delete from kutyanevek where Id=@id";
                    using (SQLiteCommand command = new SQLiteCommand(deleteCommand, connection))
                    {
                        command.Parameters.AddWithValue("@kutyanev", kutyanev.KutyaNev);
                        command.Parameters.AddWithValue("@id", kutyanev.Id);
                        var sorok = command.ExecuteNonQuery();
                        MessageBox.Show($"{sorok} sor törölve!");
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<Rendeles> GetRendelesek()
        {
            List<Rendeles> rendelesek = new List<Rendeles>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string sqlCommand = @"select kutya.Id as Id,
                                      fajtaid,
                                      nevid,
                                      eletkor,
                                      utolsoell,
                                      kutyanev,
                                      nev as fajtanev
                                      from kutya,kutyanevek,kutyafajtak
                                      where kutya.fajtaid=kutyafajtak.Id and kutya.nevid=kutyanevek.Id";
                    using (SQLiteCommand command = new SQLiteCommand(sqlCommand, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Rendeles rendeles = new Rendeles
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    NevId = Convert.ToInt32(reader["nevid"]),
                                    FajtaId = Convert.ToInt32(reader["fajtaid"]),
                                    Eletkor = Convert.ToInt32(reader["eletkor"]),
                                    UtolsoEll = reader["utolsoell"].ToString(),
                                    Fajta = reader["fajtanev"].ToString(),
                                    Nev = reader["kutyanev"].ToString()
                                };
                                rendelesek.Add(rendeles);
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





            return rendelesek;
        }

        public static void UjRendeles(Rendeles rendeles)
        {
            try
            {
                using (SQLiteConnection connection=new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string insertCommand = "insert into kutya (fajtaid,nevid,eletkor,utolsoell) values(@fajtaid,@nevid,@eletkor,@utolsoell)";
                    using (SQLiteCommand command=new SQLiteCommand(insertCommand,connection))
                    {
                        command.Parameters.AddWithValue("@fajtaid", rendeles.FajtaId);
                        command.Parameters.AddWithValue("@nevid", rendeles.NevId);
                        command.Parameters.AddWithValue("@eletkor", rendeles.Eletkor);
                        command.Parameters.AddWithValue("@utolsoell", rendeles.UtolsoEll);

                        var sorok = command.ExecuteNonQuery();
                        MessageBox.Show($"{sorok} sor beszúrva!");
                    }

                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ModositRendeles(Rendeles rendeles)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string updateCommand = "update kutya set fajtaid=@fajtaid,nevid=@nevid,eletkor=@eletkor,utolsoell=@utolsoell where Id=@id";
                    using (SQLiteCommand command = new SQLiteCommand(updateCommand, connection))
                    {
                        command.Parameters.AddWithValue("@id", rendeles.Id);
                        command.Parameters.AddWithValue("@fajtaid", rendeles.FajtaId);
                        command.Parameters.AddWithValue("@nevid", rendeles.NevId);
                        command.Parameters.AddWithValue("@eletkor", rendeles.Eletkor);
                        command.Parameters.AddWithValue("@utolsoell", rendeles.UtolsoEll);

                        var sorok = command.ExecuteNonQuery();
                        MessageBox.Show($"{sorok} sor módosítva!");
                    }

                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void TorolRendeles(Rendeles rendeles)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string deleteCommand = "delete from kutya where Id=@id";
                    using (SQLiteCommand command = new SQLiteCommand(deleteCommand, connection))
                    {
                        command.Parameters.AddWithValue("@id", rendeles.Id);
                        

                        var sorok = command.ExecuteNonQuery();
                        MessageBox.Show($"{sorok} sor törölve!");
                    }

                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
