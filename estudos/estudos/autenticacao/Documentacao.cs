using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.autenticacao
{
    internal class Documentacao
    {
        /*
          - A primeira coisa que tenho que fazer para pensarmos em autenticacao é criar o que deve ter nessa autenticacao (models)
         */

        // Fiz o model REGISTRO como o primeiro:
        [Required]
        [EmailAddress] 
        public string Email { get; set; }

        [Required] 
        [MinLength(6)] 
        public string Password { get; set; }

        /*
              - Essas duas propiedadaes que sao as basicas vem com algumas validacoes inciais:
                REQUIRED: esse campo e obrigatorio
                EMAILADDRESS: esse campo tem que vir no formato email 
                MiNLENGTH: Quantidade de carcteres minimos

                 - nessa minha primeira autenticacao foi somente essas validacoes nos models, acho que tem mais pra colocar. Tenho que pesquisar.
         */

        // Depois faco as propiedades do Usuario:
        public class User
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string PasswordHash { get; set; }
        }

        /*
           = Agora como esse exemplo e meio simples eu consigo jogar tudo no controller.
         */





    }

}
