using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using EntitiesLayer;
using DAL;

/**
 * Gestor de cursos
 * Controla la comunicacion entre las interfaces de usuario y los objetos.
 **/
namespace BLL
{
    public class GestorCursos
    {
        /**
         * Constructor Singleton del GestorCursos
         ***/
        public GestorCursos() { }
        
        /**
         * Agregar Curso
         * Metodo que permite construir un objeto tipo Curso mediante el repositorio encargado.
         **/
        public void agregarCurso(string nombre, string codigo, string precio, int cantidadCreditos)
        {
            try
            {
                Curso Curso = new Curso(-1, nombre, codigo, precio, cantidadCreditos);
                CursosRepository.Instance.Insert(Curso);
                CursosRepository.Instance.Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /**
         * Agregar Curso
         * Metodo que permite modificar un objeto tipo Curso mediante el repositorio encargado.
         **/
        public void editarCurso(int idCurso, string nombre, string codigo, string precio, int cantidadCreditos)
        {
            try
            {
                Curso Curso = CursosRepository.Instance.GetById(idCurso);
                Curso.Nombre = nombre;
                Curso.Codigo = codigo;
                Curso.Precio = precio;
                Curso.CantidadCreditos = cantidadCreditos;
                CursosRepository.Instance.Update(Curso);
                CursosRepository.Instance.Save();
            }

            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /**
        * Eliminar Curso
        * Metodo que permite eliminar un objeto tipo Curso mediante el repositorio encargado.
        **/
        public void eliminarCurso(int idCurso)
        {
            try{
                Curso Curso = CursosRepository.Instance.GetById(idCurso);
                CursosRepository.Instance.Delete(Curso);
                CursosRepository.Instance.Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /**
        * Consultar Cursos
        * Metodo que permite traer una lista de todos los cursos existentes en el sistema.
        **/
        public IEnumerable<Curso> consultarCursos()
        {
            try
            {
                return CursosRepository.Instance.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /**
        * Consultar Curso
        * Metodo que permite leer un solo curso de existente en el sistema.
        **/
        public Curso consultarCurso(int idCurso)
        {
            try{
                return CursosRepository.Instance.GetById(idCurso);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
 }
