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

          -> Registro (passos que fiz no controller, tenho que ver se precisa de mais validacoes):

             - Primeiro preciso ver se tem algum usuario que seja igual a que eu vou passar
               caso essa variavel (fiz a comparacao se existe o mesmo email) seja diferente de null
               importante passar um retorno falando que ja existe esse usuario
            
             - Se n retornar e realmente esse usuario for null, crio uma variavel onde vai guardar a senha
               passada. Neste caso essa senha vai estar criptografada com o BCRYPT
             
             - Instancio um novo usuario com o dto de email e essa variavel da senha criptografada
             
             - Neste exemplo estou usando o EF entao :
                == adiciono um novo usuario passando a minha variavel instanciada.
                == salvo as modificacoes
                == retorno um ok 

            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == dto.Email);

            if (existingUser != null)
            {
                return BadRequest("Usuário já existe");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Usuário criado");

            -> Login
            - verifico se existe esse login
            - se essa variavel onde verifico tiver nulo, caso esse email for nulo falo que tem alguma crtedencial invalida
            - passo um VERIFY do BYCRIPT, nele consigo ver se tem a mesma senha, passando as duas senhas como parametro
            - Se for falso falso essa variavel eu retorno credencial invalida
            - retorno um generateToken desse detemrinando usuario 
            - retorno o token (por enquanto)
         */





    }

}
