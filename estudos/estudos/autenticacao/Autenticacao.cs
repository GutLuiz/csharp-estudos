using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos.autenticacao
{
    internal class Autenticacao
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

        // utilizando a arquitetura MVC, agora fazemos classes de SERVICOS. nela eu consigo fazer todas as regras de negocio da minha autenticacao
        // EXEMPLO:

        /*
            public async Task<User?> RegistrarUsuario(RegisterDto dto)
            {
                var usuarioExiste = await _context.Users
                    .FirstOrDefaultAsync(t => t.Email == dto.Email);

                if (usuarioExiste != null)
                {
                    return null;
                }

                var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

                var user = new User
                {
                    Email = dto.Email.Trim().ToLower(),
                    PasswordHash = passwordHash
                };

                //_context.Users.Add(user);

                //await _context.SaveChangesAsync();

                return user;
            }
          
         -> PONTOS IMPORTANTES:
            - fiz uma pesquisa e descobri que o "certo" quando um metodo acessa o BD ele precisa ser async task.
            - fazer validacoes basicas e retornar null (para no controller retornos de mensagem)
            - passar os parametros necessarios.
 
        */

        // Adicionar o servico no PROGRAM:

        //builder.Services.AddScoped<AuthService>();

        // Controller:
        // -> Herdo a classe CONTROLLERBASE (base do ASP.NET Core usada para criar APIs.)
        // -> Passo alguns metodos basicos: [ApiController] [httpMetodo] [authorize] [[Route("nome da rota")]]
        // -> Passo como readonly o servico que vou utilizar para os meus controllers

        /*
         
            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterDto dto)
            {
                var usuario = await _authService.RegistrarUsuario(dto);

                if (usuario == null)
                {
                    return BadRequest("Usuário já existe.");
                }

                return Ok("Usuário criado com sucesso.");
            }

            -> PONTOS IMPORTANTES:
               - faco o metodo do tipo IACTIONRESULT (IActionResult é uma interface do ASP.NET Core usada nos Controllers para representar uma resposta HTTP.)
               - as maiorias dos endpoints (principalmente do tipo [authorize]) precisa da validacao do token, entao é necessario essa validacao 
                    ==  private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
               - validacao dos nulos, retornar badRequest, not found entre outros
         */









    }

}
