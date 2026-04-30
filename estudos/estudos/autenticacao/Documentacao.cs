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
            - retorno o TOKEN (por enquanto)

             public IActionResult Login([FromBody] LoginDto dto)
            {
                var user = _context.Users
                    .FirstOrDefault(u => u.Email == dto.Email);

                if (user == null)
                {
                    return Unauthorized("Credenciais inválidas");
                }

                var validPassword = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

                if (!validPassword)
                {
                    return Unauthorized("Credenciais inválidas");
                }
                
                var token = _tokenService.GenerateToken(user);

                return Ok(new
                {
                    token = token
                });
            }
            // sei que n tem que retornar o token assim mas pra teste, e o suficiente.
            // preciso melhorar osa logs, mensagens mais claras.
            // preiciso ver se tem a necessidade de mais validacoes dentro desses dois controllers
         */


        /*
          -> O QUE SERIA ESSE TOKEN RETORNANDO NO MEU EXEMPLO DE LOGIN?
            - Basicamente do que eu sei e uma "chave" ele tem tres partes e e totalmente aleatorio
            - ele serve pra autorizar o usuario a fazer uma determinada acao que precise de AUTORIZACAO
            - por exemplo excluir uma categoria, esse token valida q esse usuario pode fazer isso.
            - ele pode ter diverser claims (corpo do token que busca essa validacao) mas por enquanto vamos focar no padrao
            
            // primeiro eu chamo essas duas linhas de codigo config (eu acho).
             var key = Encoding.ASCII.GetBytes(JwtSettings.Key);
             var tokenHandler = new JwtSecurityTokenHandler();
            // depois eu posso usar o token descriptor que faz uma serie de configuracoes do meu token
             var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = JwtSettings.Issuer,
                Audience = JwtSettings.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            // o que eu vou focar agora e no SUBJECT. Onde tem o CLAIMSIDENTITY
            // ele cria uma claim colocando o id e o email para identificar nosso usuario
            // importanate passar como parametro tudo isso. acho qye tb tem que ser em string

            // dps cria o token e retorna
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

            importante tambem colocar isso no program mas n sei mt o que e, vou pesquisar depois

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,

                    ValidIssuer = JwtSettings.Issuer,
                    ValidAudience = JwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });


         */







    }

}
