﻿using System;
using System.Text;

namespace GeradorRPG
{
    internal class Program
    {
        private static void Main()
        {

            #region Declaração de delegates

            #region Raças

            #region Anão

            RacaHandler addAnao = personagem =>
            {
                personagem.Raca = "Anão";
                personagem.HP += 200;
                personagem.Stamina += 300;
                personagem.Mana -= 25;
            };

            RacaHandler removeAnao = personagem =>
            {
                personagem.HP -= 200;
                personagem.Stamina -= 300;
                personagem.Mana += 25;
            };

            #endregion

            #region Elfo

            RacaHandler addElfo = personagem =>
            {
                personagem.Raca = "Elfo";
                personagem.HP -= 50;
                personagem.Stamina += 100;
                personagem.Mana += 500;
            };

            RacaHandler removeElfo = personagem =>
            {
                personagem.HP += 50;
                personagem.Stamina -= 100;
                personagem.Mana -= 500;
            };

            #endregion

            #region Cyborg

            RacaHandler addCyborg = personagem =>
            {
                personagem.Raca = "Cyborg";
                personagem.HP += 500;
                personagem.Stamina += 2000;
                personagem.Mana -= 1000;
            };

            RacaHandler removeCyborg = personagem =>
            {
                personagem.HP -= 500;
                personagem.Stamina -= 2000;
                personagem.Mana += 1000;
            };

            #endregion

            #endregion

            #region Classes

            #region Mago

            ClasseHandler addMago = personagem =>
            {
                personagem.Mana += 2500;
                personagem.Cota = "Manto Sagrado";
                personagem.Calcas = "Calças de Merlin";
                personagem.AdicionarArmaFromClasse("Cajado");
                personagem.AdicionarClasse("mago");
            };

            ClasseHandler removeMago = personagem =>
            {
                personagem.Mana -= 2500;
                personagem.RemoverClasse("mago");
            };

            #endregion

            #region Guerreiro

            ClasseHandler addGuerreiro = personagem =>
            {
                personagem.HP += 1000;
                personagem.Stamina += 1500;
                personagem.Cota = "Armadura de Aço";
                personagem.Calcas = "Calças de Ferro";
                personagem.AdicionarArmaFromClasse("Espada");
                personagem.AdicionarClasse("guerreiro");
            };

            ClasseHandler removeGuerreiro = personagem =>
            {
                personagem.HP -= 1000;
                personagem.Stamina -= 1500;
                personagem.RemoverClasse("guerreiro");
            };

            #endregion

            #region Ladrao

            ClasseHandler addLadrao = personagem =>
            {
                personagem.HP += 500;
                personagem.Stamina += 1500;
                personagem.Mana += 500;
                personagem.Cota = "Túnica das Sombras";
                personagem.Calcas = "Cuecas da Morte";
                personagem.AdicionarArmaFromClasse("Lâminas");
                personagem.AdicionarClasse("ladrão");
            };

            ClasseHandler removeLadrao = personagem =>
            {
                personagem.HP -= 500;
                personagem.Stamina -= 1500;
                personagem.Mana -= 500;
                personagem.RemoverClasse("ladrão");
            };

            #endregion

            #endregion

            #region Profissões

            #region Ferreiro

            ProfissaoHandler addFerreiro = personagem =>
            {
                personagem.Profissao = "ferreiro";
                personagem.Sapatos = "Sapatos de couro";
                personagem.Bracadeiras = "Manoplas Rígidas";
                personagem.Capacete = "Capuz de Minish";
                personagem.AdicionarArmaFromProfissao("de aço");
            };

            #endregion

            #region Assassino

            ProfissaoHandler addAssassino = personagem =>
            {
                personagem.Profissao = "assassino";
                personagem.Sapatos = "Pantufas das Sombras";
                personagem.Bracadeiras = "Luvas do Sangue";
                personagem.Capacete = "Máscara da noite";
                personagem.AdicionarArmaFromProfissao("do Apocalipse");
            };

            #endregion

            #region Mensageiro

            ProfissaoHandler addMensageiro = personagem =>
            {
                personagem.Profissao = "mensageiro";
                personagem.Sapatos = "Sandálias do Vento";
                personagem.Bracadeiras = "Pulseiras da Flutuação";
                personagem.Capacete = "Tiara do Sonic";
                personagem.AdicionarArmaFromProfissao("da Leveza");
            };

            #endregion

            #endregion

            #region Moradias

            #region Oceanicas

            MoradiaHandler addOceano = personagem =>
            {
                personagem.Moradia = "Oceano";
                personagem.Mana += 5000;
            };
            MoradiaHandler removeOceano = personagem =>
            {
                personagem.Mana -= 5000;
            };

            #endregion

            #region Vulcânicas

            MoradiaHandler addVulcanico = personagem =>
            {
                personagem.Moradia = "Vulcão";
                personagem.HP += 5000;
            };
            MoradiaHandler removeVulcanico = personagem =>
            {
                personagem.HP -= 5000;
            };

            #endregion

            #region Florestalicas

            MoradiaHandler addFlorestalicas = personagem =>
            {
                personagem.Moradia = "Mato";
                personagem.Stamina += 5000;
            };
            MoradiaHandler removeFlorestalicas = personagem =>
            {
                personagem.Stamina -= 5000;
            };

            #endregion

            #endregion

            #endregion

            #region Criando um personagem
            
            var fac = new PersonagensFactory();



            fac.StartPersonagemCreation("Apolyon");
            fac.AttributeRace(addAnao);
            fac.AttributeClass(addLadrao);
            fac.AttributeClass(addGuerreiro);
            fac.DismissClass(removeLadrao);
            fac.AttributeMoradia(addOceano);
            
            fac.AttributeProfissao(addMensageiro);

            try
            {
                EscreverPersonagem(fac);
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);

            }
            #endregion

            #region Criando persoangems aleatorios
            
            #endregion
            Console.WriteLine("Pronto para gerar personagems aleatórios");
                Console.ReadLine();

            for (;;)
            {
                var rnd = new Random();
                try
                {
                    fac.StartPersonagemCreation(nomes[rnd.Next(0,nomes.Length)]);


                    var racas = new RacaHandler[] { addAnao, addElfo, addCyborg };
                    var classes = new ClasseHandler[] { addGuerreiro, addMago, addLadrao };
                    var profissoes = new ProfissaoHandler[] { addFerreiro, addMensageiro, addAssassino };
                    var moradias = new MoradiaHandler[] { addOceano, addVulcanico, addFlorestalicas };


                    fac.AttributeRace(racas[rnd.Next(0, 3)]);
                    fac.AttributeClass(classes[rnd.Next(0, 3)]);
                    fac.AttributeProfissao(profissoes[rnd.Next(0, 3)]);
                    fac.AttributeMoradia(moradias[rnd.Next(0, 3)]);


                    EscreverPersonagem(fac);
                    Console.WriteLine("<Enter> para gerar outro.");
                    Console.ReadKey();

                }
                catch (Exception exe)
                {
                    Console.WriteLine(exe.Message);

                }



            }
        
        }

        private static void EscreverPersonagem(PersonagensFactory fac)
        {
            Console.Clear();
            var p = fac.GetPersonagem();

            var sb = new StringBuilder();
            sb.AppendLine(p.ToString());
            sb.AppendLine("Nome: " + p.Nome);

            sb.AppendLine("\nAtributos:");
            sb.AppendLine("HP: " + p.HP);
            sb.AppendLine("Mana: " + p.Mana);
            sb.AppendLine("Stamina: " + p.Stamina);


            sb.AppendLine("\nFunção no mundo:");
            sb.AppendLine("Raca: " + p.Raca);
            sb.AppendLine("Classes: " + p.Classes);
            sb.AppendLine("Profissao: " + p.Profissao);
            sb.AppendLine("Moradia: " + p.Moradia);

            sb.AppendLine("\nFunção no mundo:");
            sb.AppendLine("Cota: " + p.Cota);
            sb.AppendLine("Calcas: " + p.Calcas);
            sb.AppendLine("Sapatos: " + p.Sapatos);
            sb.AppendLine("Bracadeiras: " + p.Bracadeiras);
            sb.AppendLine("Capacete: " + p.Capacete);
            sb.AppendLine("Arma: " + p.Arma);

            Console.WriteLine('\n');
            Console.WriteLine(sb);
        }
     private static string[] nomes = new[]
        {
            "Rá", "Toth", "Anúbis", "Bastet", "Hathor", "Hórus", "Khnum", "Maet", "Ptah", "Seth", "Sobek", "Osíris", "Ísis",
            "Tefnut", "Chu", "Geb", "Zeus", "Afrodite", "Ares", "Hades", "Hera", "Poseidon", "Eros", "Héstia", "Apolo",
            "Ártemis", "Deméter", "Dionísio", "Hermes", "Hefesto", "Crono", "Gaia"
        };
    }
}

    