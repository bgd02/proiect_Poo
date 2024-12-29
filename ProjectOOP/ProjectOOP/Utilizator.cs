namespace ConsoleApp1
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public abstract class Utilizator
    {
        private string NumarMatricol;

        public string numarMatricol
        {
            get { return NumarMatricol; }
            set
            {
                if (value.Length == 5 && int.TryParse(value, out _))
                {
                    NumarMatricol = value;
                }
                else
                {
                    throw new ArgumentException("Numarul matricol trebuie sa contina doar 5 caractere (ex: 00000).");
                }
            }
        }

        protected string NumePrenume;

        public string numePrenume
        {
            get { return NumePrenume; }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    NumePrenume = value;
                }
                else
                {
                    throw new ArgumentException("Numele trebuie sa contina doar litere.");
                }
            }
        }

        private string Email;

        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        private string Parola;

        public string parola
        {
            get { return Parola; }
            set
            {
                if (Regex.IsMatch(value, @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?"":{}|<>])$"))
                {
                    Parola = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Parola trebuie sa contina cel putin o litera mare, un caracter special si o cifra.");
                }
            }
        }

        public Utilizator(string numarMatricol, string numePrenume, string email, string parola)
        {
            this.NumarMatricol = numarMatricol;
            this.NumePrenume = numePrenume;
            this.Email = email;
            this.parola = parola;
        }

        public abstract string showMenu();
    }
}
    