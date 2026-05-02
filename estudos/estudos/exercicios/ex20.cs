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
            public PacientesDto paciente { get; set; }
            public MedicosDto medico { get; set; }
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

            private int _contagemid = 0;

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

            private int _contagemid = 0;

            public Consultas(Pacientes paciente, Medicos medico)
            {
                _contagemid++;
                _id = _contagemid;
                _paciente = paciente;
                _medico = medico;
                _data = DateTime.Now.ToString("dddd/MM/yyyy");
                _status = "Consulta Marcada";
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
                else if(dto.cpf == null )
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
                else if (dto.valor_consulta == null)
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
        public class ConsultasServico
        {
            private PacienteRepository _pacienteRepository;
            private MedicosRepository _medicosRepository;

            public ConsultasServico(PacienteRepository pacienteRepository, MedicosRepository medicosRepository)
            {
                _pacienteRepository = pacienteRepository;
                _medicosRepository = medicosRepository;
            }

            public void AgendarConsulta(ConsultaDto dto)
            {
                if (dto.paciente == null)
                {
                    Console.WriteLine("Paciente nulo");
                    return;
                }
                else if(dto.medico == null)
                {
                    Console.WriteLine("Medico nulo");
                    return;
                }
                else
                {
                    var paciente = _pacienteRepository.BuscarPorNome(dto.paciente.nome);
                    var medico = _medicosRepository.BuscarPorNome(dto.medico.nome);

                    new Consultas(paciente, medico);
                }
            }
            public void CancelarConsulta(Consultas c)
            {
                c.AlterarStatus("Cancelado");
            }
        }
        

    }
}
