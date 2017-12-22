using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fructuseur
{
    class Program
    {
        // Initialisation
        static void Main(string[] args)
        {
            Console.WriteLine("[0.1.0] Bienvenue sur Fructuseur !");
            string cmd = "";
            while (cmd != "quit")
            {
                Console.Write("Entrez une commande: ");
                cmd = Console.ReadLine();
                cmd = cmd == "default" ? "default_f" : cmd;
                Console.WriteLine(Commandes.get(cmd));
            }
            Environment.Exit(0);
        }
    }
    public static class Commandes
    {
        public static string currentCmd = "";
        static string[] listeCommandes =
        {
            // Commandes essentielles
            "update",
            "create",
            "page",
            "default_f",
            // Commandes d'ajout
            "font",
            "responsive",
            "cdn",
            "cdnvar",
            "css",
            "js"
        };

        // Tester l'existence de la commande
        public static string get(string cmd)
        {
            string[] cmds = cmd.Split(' ');
            cmd = cmds[0];
            if (Commandes.listeCommandes.Contains(cmd))
            {
                Commandes.currentCmd = cmds.Length > 1 ? cmds[1] : "";
                for(var i = 1; cmds.Length > i+1; i++)
                {
                    Commandes.currentCmd += ' ' + cmds[i+1];
                }
                Type type = typeof(Execute);
                MethodInfo method = type.GetMethod(cmd);
                Execute inv = new Execute();
                string result = (string)method.Invoke(inv, null);
                return "Tâche effectuée";
            }
            else
            {
                return "Tâche inexistante";
            }
        }

        // Créer un dossier
        public static bool creerDossier(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Création du dossier " + path);
                Directory.CreateDirectory(path);
                return true;
            }
            else return false;
        }

        // Télécharger un fichier
        public static bool telechargerFichier(string url, string path, string fname)
        {
            url += ".txt";
            Console.WriteLine("Téléchargement du fichier http://iazlur.fr/fructuseur/" + url);
            string fichier = (new WebClient()).DownloadString("http://iazlur.fr/fructuseur/" + url);
            string p = path.Length > 1 ? @"\" : "";
            if (!File.Exists(path + p + fname))
            {
                Console.WriteLine("Ecriture du fichier " + path + p + fname);
                FileStream fs1 = new FileStream(path + p + fname, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);
                writer.Write(fichier);
                writer.Close();
                return true;
            }
            else return false;
        }

        // Créer un fichier
        public static bool creerFichier(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Création du fichier vide " + path);
                var f = File.Create(path);
                f.Close();
                return true;
            }
            else return false;
        }

        // Ajouter une valeur au registre
        public static void ajouterKey(string name, string value)
        {
            if (Registry.CurrentUser.OpenSubKey("fructuseur", false) == null)
                Registry.CurrentUser.CreateSubKey("fructuseur", true);
            RegistryKey key = Registry.CurrentUser.OpenSubKey("fructuseur", true);
            Console.WriteLine("Valeur de registre modifiée.");
            key.SetValue(name, value);
            key.Close();
        }

        // Prendre une valeur au registre
        public static string prendreKey(string name)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("fructuseur");
            var value = key.GetValue(name);
            if (value != null)
            {
                Console.WriteLine("Valeur de registre récupérée");
                return value.ToString();
            }
            else
            {
                Console.WriteLine("Valeur de registre inexistante");
                return "error";
            }
        }

        // Ajouter une ligne à un fichier
        public static bool ajouterCode(string path, string code)
        {
            if (File.Exists(path))
            {
                FileStream fs1 = new FileStream(path, FileMode.Open, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);
                long endPoint = fs1.Length;
                fs1.Seek(endPoint, SeekOrigin.Begin);
                writer.WriteLine(code);
                writer.Flush();
                writer.Close();
                return true;
            }
            else return false;
        }

        // Copier fichier et supprimer
        public static bool copierEtSupprimer(string path, string path2)
        {
            if (File.Exists(path))
            {
                Console.WriteLine("Copie et suppression de " + path);
                File.SetAttributes(path, FileAttributes.Normal);
                if (!File.Exists(path2))
                {
                    File.Copy(path, path2);
                }
                File.SetAttributes(path2, FileAttributes.Normal);
                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + path);
                return true;
            }
            else return false;
        }

        // Parser la commande
        public static void parseCmd()
        {
            Commandes.currentCmd = Commandes.currentCmd.Replace(' ', '_').Replace('\'', '_').ToLower();
        }
    }
    class Execute
    {
        // Commandes essentielles
        public void update()
        {
            if (!Commandes.creerDossier("bin")) Console.WriteLine("Un projet semble déjà exister");
            Commandes.creerDossier("css");
            Commandes.creerDossier("js");
            Commandes.creerDossier("web");
            Commandes.creerDossier(@"bin\php");
            Commandes.creerDossier(@"bin\inc");
            Commandes.creerDossier(@"bin\css");
            Commandes.telechargerFichier("bin/php/base.php", @"bin\php", "base.php");
            Commandes.telechargerFichier("bin/php/router.php", @"bin\php", "router.php");
            Commandes.telechargerFichier("bin/php/loader.php", @"bin\php", "loader.php");
            Commandes.telechargerFichier("bin/php/cdn.php", @"bin\php", "cdn.php");
            Commandes.telechargerFichier("bin/inc/start.inc.php", @"bin\inc", "start.inc.php");
            Commandes.telechargerFichier("bin/inc/end.inc.php", @"bin\inc", "end.inc.php");
            Commandes.telechargerFichier("index.php", "", "index.php");
            Commandes.creerFichier(@"bin\css\fonts.css");
        }
        public void create()
        {
            Console.WriteLine("Création du projet");
            Commandes.ajouterCode(@"bin\php\loader.php", "echo '<title>" + Commandes.currentCmd + "</title>';");
        }
        public void page()
        {
            Console.WriteLine("Création de la page");
            Commandes.parseCmd();
            Commandes.ajouterCode(@"bin\php\router.php", "addPage('" + Commandes.currentCmd + "');");
            string fichier = @"web\" + Commandes.currentCmd + ".php";
            Commandes.creerFichier(fichier);
            Commandes.ajouterCode(fichier, "<body>");
            Commandes.ajouterCode(fichier, "    ");
            Commandes.ajouterCode(fichier, "</body>");
        }
        public void default_f()
        {
            Console.WriteLine("Attribution de la page par défaut");
            Commandes.parseCmd();
            Commandes.ajouterCode(@"bin\php\router.php", "setDefault('" + Commandes.currentCmd + "');");
        }
        // Commandes d'ajout
        public void font()
        {
            string[] cmds = Commandes.currentCmd.Split(' ');
            if (cmds.Length == 2)
            {
                if (!Commandes.copierEtSupprimer(cmds[0], @"bin\css\" + cmds[0])) Console.WriteLine("Le fichier n'existe pas.");
                else
                {
                    Console.WriteLine("Ajout de la police '" + cmds[1] + "' au projet");
                    string fichier = @"bin\css\fonts.css";
                    Commandes.ajouterCode(fichier, "@font-face");
                    Commandes.ajouterCode(fichier, "{");
                    Commandes.ajouterCode(fichier, "    font-family: '" + cmds[1] + "';");
                    Commandes.ajouterCode(fichier, "    src: url('" + cmds[0] + "');");
                    Commandes.ajouterCode(fichier, "}");
                }
            }
            else Console.WriteLine("Commande invalide");
        }
        public void responsive()
        {
            string[] cmds = Commandes.currentCmd.Split(' ');
            if (cmds.Length == 2 && (cmds[0] == "min" || cmds[0] == "max"))
            {
                Console.WriteLine("Création du fichier en cascade responsive");
                string fichier = @"css\responsive." + cmds[0] + "." + cmds[1] + "px.css";
                Commandes.creerFichier(fichier);
                Commandes.ajouterCode(fichier, "@media screen and (" + cmds[0] + "-width: " + cmds[1] + "px)");
                Commandes.ajouterCode(fichier, "{");
                Commandes.ajouterCode(fichier, "    ");
                Commandes.ajouterCode(fichier, "}");
            }
            else Console.WriteLine("Commande invalide");
        }
        public void cdn()
        {
            string[] cmds = Commandes.currentCmd.Split(' ');
            if (cmds.Length == 2 && (cmds[0] == "css" || cmds[0] == "js"))
            {
                if(!cmds[1].Contains("http"))
                {
                    cmds[1] = Commandes.prendreKey(cmds[1]);
                    if (cmds[1] == "error")
                    {
                        Console.WriteLine("Impossible d'ajouter le cdn.");
                        return;
                    }
                }
                Console.WriteLine("Ajout du cdn");
                if (cmds[0] == "css")
                {
                    Commandes.ajouterCode(@"bin\php\cdn.php", "<link rel=\"stylesheet\" type=\"text/css\" href=\"" + cmds[1] + "\">");
                }
                else
                {
                    Commandes.ajouterCode(@"bin\php\cdn.php", "<script src=\"" + cmds[1] + "\"></script>");
                }
            }
            else Console.WriteLine("Commande invalide");
        }
        public void cdnvar()
        {
            string[] cmds = Commandes.currentCmd.Split(' ');
            if (cmds.Length == 2)
            {
                Console.WriteLine("Ajout de la variable cdn");
                Commandes.ajouterKey(cmds[0], cmds[1]);
            }
            else Console.WriteLine("Commande invalide");
        }
        public void css()
        {
            Commandes.parseCmd();
            Console.WriteLine("Création du fichier css");
            if (!Commandes.creerFichier(@"css\" + Commandes.currentCmd + ".css")) Console.WriteLine("Impossible");
        }
        public void js()
        {
            Commandes.parseCmd();
            Console.WriteLine("Création du fichier js");
            if (!Commandes.creerFichier(@"js\" + Commandes.currentCmd + ".js")) Console.WriteLine("Impossible");
        }
    }
}
