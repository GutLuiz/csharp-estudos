using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace estudos.exercicios
{
    internal class ex20
    {
        public class PacientesDto
        {
            public string nome { get; set; }
            public int cpf { get; set; }
            public string data_nascimento { get; set; }
            public bool plano { get; set; }
        }
        public class MedicosDto
        {
            public string nome { get; set; }
            public string crm { get; set; }
            public string especialidade { get; set; }
            public decimal valor_consulta { get; set; }
        }
        public class ConsultaDto
        {
            public string NomePaciente { get; set; }  
            public string NomeMedico { get; set; }
        }

        public class Pacientes
        {
            private int _id;
            private string _nome;
            private int _cpf;
            private string _data_nascimento;
            private bool _plano;

            private int _contagemid = 0;

            public Pacientes (string nome, int cpf, string nacimento, bool plano)
            {
                _contagemid++;
                _id = _contagemid;
                _nome = nome;
                _cpf = cpf;
                _data_nascimento = nacimento;
                _plano = plano;
            }

            public bool ObterPlano()
            {
                return _plano;
            }
            public string ObterNome()
            {
                return _nome;
            }
        }
        public class Medicos
        {
            private int _id;
            private string _nome;
            private string _crm;
            private string _especialidade;
            private decimal _valor_consulta;

            private static int _contagemid = 0;

            public Medicos(string nome, string crm, string especialidade, decimal valor_consulta)
            {
                _contagemid++;
                _id = _contagemid;
                _nome = nome;
                _crm = crm;
                _especialidade = especialidade;
                _valor_consulta = valor_consulta;
            }
            public decimal ObterValorConsulta()
            {
                return _valor_consulta;
            }
            public string ObterNome()
            {
                return _nome;
            }
        }
        public class Consultas {

            private int _id;
            private Pacientes _paciente;
            private Medicos _medico;
            private string _data;
            private string _status;
            private decimal _valor_cobrado;

            private static int _contagemid = 0;

            public Consultas(Pacientes paciente, Medicos medico)
            {
                _contagemid++;
                _id = _contagemid;
                _paciente = paciente;
                _medico = medico;
                _data = DateTime.Now.ToString("dddd/MM/yyyy");
                _status = "Realizada";
                _valor_cobrado = Desconto();
            }

            public decimal Desconto()
            {
                decimal valor = _medico.ObterValorConsulta();

                if (_paciente.ObterPlano() == true)
                {
                    valor = valor / 2;
                }

                return valor;
            }
            public void AlterarStatus(string stts)
            {
                _status = stts;
            }
            public string ObterStatus()
            {
                return _status;
            }
            public decimal ObterValorCobrado()
            {
                return _valor_cobrado;
            }
            public override string ToString()
            {
                return $"Id: {_id}, paciente: " +
                    $"{_paciente}, medico:" +
                    $" {_medico}, data:{_data}," +
                    $" {_status}, valor cobrado: {_valor_cobrado}";
            }
        }

        public class PacienteRepository
        {
            private List<Pacientes> _p = new List<Pacientes>();

            public void SalvarPaciente(Pacientes p)
            {
                _p.Add(p);
            }
            public Pacientes BuscarPorNome(string nome)
            {
                foreach(Pacientes p in _p)
                {
                    if(p.ObterNome() == nome)
                    {
                        return p;
                    }
                }
                return null;
            }
        }
        public class PacienteServico 
        {
            private PacienteRepository _pacienteRepository;

            public PacienteServico(PacienteRepository pacienteRepository)
            {
                _pacienteRepository = pacienteRepository;
            }

            public void AdicionarPaciente(PacientesDto dto)
            {
                if(dto.nome == null)
                {
                    Console.WriteLine("Nome nao pode ser nulo");
                    return;
                }
                else if(dto.cpf == 0 )
                {
                    // fazendo a validacao errada pq tem q especificar algms coisa mas n leve isso em consideracao ok
                    Console.WriteLine("Cpf nao pode ser nulo");
                    return;
                }
                else if(dto.data_nascimento == null)
                {
                    Console.WriteLine("Data de nascimento nao pode ser nula");
                    return;
                }
                else if(dto.plano == null)
                {
                    Console.WriteLine("plano nao pode ser nulo");
                    return; 
                }
                else
                {
                    var paciente = new Pacientes(dto.nome, dto.cpf, dto.data_nascimento, dto.plano);
                    _pacienteRepository.SalvarPaciente(paciente);
                }
            }
        }
        public class MedicosRepository
        {
            private List<Medicos> _m = new List<Medicos>();

            public void SalvarMedico(Medicos m)
            {
                _m.Add(m);
            }
            public Medicos BuscarPorNome(string nome)
            {
                foreach (Medicos m in _m)
                {
                    if (m.ObterNome() == nome)
                    {
                        return m;
                    }
                }
                return null;
            }
        }
        public class MedicoServico
        {
            private MedicosRepository _medicosRepository;

            public MedicoServico(MedicosRepository medicosRepository)
            {
                _medicosRepository = medicosRepository;
            }
            public void AdicionarMedico(MedicosDto dto)
            {
                if (dto.nome == null)
                {
                    Console.WriteLine("Nome nao pode ser nulo");
                    return;
                }
                else if (dto.crm == null)
                {
                    Console.WriteLine("Crm nao pode ser nulo");
                    return;
                }
                else if (dto.especialidade == null)
                {
                    Console.WriteLine("Especialidade nao pode ser nulo");
                    return;
                }
                else if (dto.valor_consulta == 0)
                {
                    Console.WriteLine("valor_consulta nao pode ser nulo");
                    return;
                }
                else
                {
                    var criarMedico = new Medicos(dto.nome, dto.crm, dto.especialidade, dto.valor_consulta);
                    _medicosRepository.SalvarMedico(criarMedico);
                }
            }
        }
        public class ConsultaRepository
        {
            private List<Consultas> _c = new List<Consultas>();

            public void SalvarConsulta(Consultas c)
            {
                _c.Add(c);
            }
            public List<Consultas> ListarConsultas()
            {
                return _c;
            }
            public List<Consultas> ListarConsultasRealizadas()
            {
                List<Consultas> realizadas = new List<Consultas>();
                foreach (Consultas c in _c)
                {
                    if (c.ObterStatus() == "Realizada")
                        realizadas.Add(c);
                }
                return realizadas;
            }
           
           

        }
        public class ConsultasServico
        {
            private PacienteRepository _pacienteRepository;
            private MedicosRepository _medicosRepository;
            private ConsultaRepository _consultaRepository;

            public ConsultasServico(PacienteRepository pacienteRepository, MedicosRepository medicosRepository, ConsultaRepository consultaRepository)
            {
                _pacienteRepository = pacienteRepository;
                _medicosRepository = medicosRepository;
                _consultaRepository = consultaRepository;
            }

            public void AgendarConsulta(ConsultaDto dto)
            {
                if (dto.NomePaciente == null)
                {
                    Console.WriteLine("Paciente nulo");
                    return;
                }
                else if(dto.NomeMedico == null)
                {
                    Console.WriteLine("Medico nulo");
                    return ;
                }
                else
                {
                    var paciente = _pacienteRepository.BuscarPorNome(dto.NomePaciente);
                    var medico = _medicosRepository.BuscarPorNome(dto.NomeMedico);

                    var consulta = new Consultas(paciente, medico);

                    _consultaRepository.SalvarConsulta(consulta);
                }
            }
            public decimal Faturamento()
            {
                decimal valorFaturamento = 0;
                foreach (Consultas c in _consultaRepository.ListarConsultas())
                {
                    valorFaturamento += c.ObterValorCobrado();
                }
                return valorFaturamento;
            }
            public void CancelarConsulta(Consultas c)
            {
                c.AlterarStatus("Cancelado");
            }
            public List<Consultas> ListarConsultas()
            {
                return _consultaRepository.ListarConsultas();
            }
            public List<Consultas> ListarConsultasRealizadas()
            {
                return _consultaRepository.ListarConsultasRealizadas();
            }


        }
        public void Executar()
        {
            PacienteRepository pr = new PacienteRepository();
            MedicosRepository mr = new MedicosRepository();
            ConsultaRepository cr = new ConsultaRepository();

            PacienteServico ps = new PacienteServico(pr);
            MedicoServico ms = new MedicoServico(mr);
            ConsultasServico cs = new ConsultasServico(pr, mr,cr);

            PacientesDto Paciente1 = new PacientesDto { nome = "Gustavo", cpf = 1231313104, data_nascimento = "01/05/2025", plano = true };
            MedicosDto Medico1 = new MedicosDto { nome = "juliana", crm = "2dadadadad", especialidade = "dermatologista", valor_consulta = 100 };
            ConsultaDto consulta1 = new ConsultaDto { NomeMedico = Medico1.nome, NomePaciente = Paciente1.nome};

            ps.AdicionarPaciente(Paciente1);
            ms.AdicionarMedico(Medico1);
            cs.AgendarConsulta(consulta1);

            foreach(var c in cs.ListarConsultas())
            {
                Console.WriteLine(c);
            }
            foreach(var c in cs.ListarConsultasRealizadas())
            {
                Console.WriteLine(c);
            }

        }

    }
}
