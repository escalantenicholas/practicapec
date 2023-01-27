using LINQtoCSV;
using pecanopractico.Interfaces;
using pecanopractico.Models;
using pecanopractico.Views;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace pecanopractico.Repository
{
    public class TrabajadorRepository : ITrabajadorRepository
    {
        public List<TrabajadorView> GetAll()
        {

            List<Trabajador> trabajadores = new List<Trabajador>();
            trabajadores = GetCsv();

            List<TipoTrabajador> tipoTrabajador = new List<TipoTrabajador>();
            tipoTrabajador = GetTipoTrabajador();

            List<TrabajadorView> trabajadoresView = new List<TrabajadorView>();

            foreach (var item in trabajadores)
            {

                TipoTrabajador? tipo = new TipoTrabajador();
                tipo = tipoTrabajador.Where(x => x.IdTipoTrabajador == item.IdTipoTrabajador).FirstOrDefault();

                var trabajadorView = new TrabajadorView();
                trabajadorView.Dni = item.Dni;
                decimal sueldoPorHora = tipo == null ? 0 : tipo.HoraLaborada;
                decimal sueldoBruto = (item.HorasLaboradas * sueldoPorHora) * item.DiasLaborados;
                decimal descuento = tipo == null ? 0 : tipo.Falta;
                decimal descuentoPorFalta = item.Faltas * descuento;
                decimal bonificacion = tipo == null ? 0 : tipo.Bonificacion;
                decimal sueldoSinImpuestos = (sueldoBruto - descuentoPorFalta) + bonificacion;
                double porcentajeImpuesto = tipo == null ? 0 :  tipo.Impuesto;
                double impuesto = Decimal.ToDouble(sueldoSinImpuestos) * porcentajeImpuesto;
                trabajadorView.Salario = Decimal.ToDouble(sueldoSinImpuestos) - impuesto;
                trabajadorView.TipoTrabajador = tipo == null ? " " : tipo.NombreTipoTrabajador;
                trabajadoresView.Add(trabajadorView);
                
            }

            IEnumerable<TrabajadorView>? enumerable = trabajadoresView as IEnumerable<TrabajadorView>;
            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = '|',
            };

            var csvContext = new CsvContext();
            csvContext.Write(enumerable, "listasalarios.csv", csvFileDescription);
            Console.WriteLine("Se creo el archivo listarsalarios.csv");

            return trabajadoresView;
        }
        
        public TrabajadorView GetByDni(string dni)
        {
            List<Trabajador> trabajadores = GetCsv();

            List<TipoTrabajador> tipoTrabajador = GetTipoTrabajador();

            var trabajadorView = new TrabajadorView();

            var trabajadorPorDni = trabajadores.Where(x => x.Dni == dni).FirstOrDefault();

            var tipo = tipoTrabajador.Where(x => x.IdTipoTrabajador == (trabajadorPorDni == null ? 4 : trabajadorPorDni.IdTipoTrabajador)).FirstOrDefault();
       
            trabajadorView.Dni = trabajadorPorDni == null ? " " : trabajadorPorDni.Dni;
            decimal sueldoPorHora = tipo == null ? 0 : tipo.HoraLaborada;
            decimal sueldoBruto = ((trabajadorPorDni == null ? 0 :trabajadorPorDni.HorasLaboradas) * sueldoPorHora) * (trabajadorPorDni == null ? 0 : trabajadorPorDni.DiasLaborados);
            decimal descuento = tipo == null ? 0 : tipo.Falta;
            decimal descuentoPorFalta = trabajadorPorDni == null ? 0 : trabajadorPorDni.Faltas * descuento;
            decimal bonificacion = tipo == null ? 0 : tipo.Bonificacion;
            decimal sueldoSinImpuestos = (sueldoBruto - descuentoPorFalta) + bonificacion;
            double porcentajeImpuesto = tipo == null ? 0 : tipo.Impuesto;
            double impuesto = Decimal.ToDouble(sueldoSinImpuestos) * porcentajeImpuesto;
            trabajadorView.Salario = Decimal.ToDouble(sueldoSinImpuestos) - impuesto;
            trabajadorView.TipoTrabajador = tipo == null ? " " : tipo.NombreTipoTrabajador;

            return trabajadorView;
        }

        public List<Trabajador> GetCsv()
        {
            string[] csv = File.ReadAllLines("./Csv/DataPractica1.csv");

            List<Trabajador> trabajadores = new List<Trabajador>();

            foreach (var itemCsv in csv.Skip(1))
            {
                var valores = itemCsv.Split('|');
                var trabajador = new Trabajador();
                trabajador.Dni = valores[0];
                trabajador.HorasLaboradas = decimal.Parse(valores[1]);
                trabajador.DiasLaborados = decimal.Parse(valores[2]);
                trabajador.Faltas = decimal.Parse(valores[3]);
                trabajador.IdTipoTrabajador = int.Parse(valores[4]);
                trabajadores.Add(trabajador);
            }

            return trabajadores;
        }

        public List<TipoTrabajador> GetTipoTrabajador()
        {
            List<TipoTrabajador> tipoTrabajador = new List<TipoTrabajador>();

            var obrero = new TipoTrabajador();
            obrero.IdTipoTrabajador = 0;
            obrero.NombreTipoTrabajador = "Obrero";
            obrero.HoraLaborada = 15;
            obrero.Falta = 120;
            obrero.Bonificacion = 130;
            obrero.Impuesto = 0.12;
            tipoTrabajador.Add(obrero);

            var supervisor = new TipoTrabajador();
            supervisor.IdTipoTrabajador = 1;
            supervisor.NombreTipoTrabajador = "Supervisor";
            supervisor.HoraLaborada = 35;
            supervisor.Falta = 280;
            supervisor.Bonificacion = 200;
            supervisor.Impuesto = 0.16;
            tipoTrabajador.Add(supervisor);

            var gerente = new TipoTrabajador();
            gerente.IdTipoTrabajador = 2;
            gerente.NombreTipoTrabajador = "Gerente";
            gerente.HoraLaborada = 85;
            gerente.Falta = 680;
            gerente.Bonificacion = 350;
            gerente.Impuesto = 0.18;
            tipoTrabajador.Add(gerente);

            return tipoTrabajador;

        }
    }
}
