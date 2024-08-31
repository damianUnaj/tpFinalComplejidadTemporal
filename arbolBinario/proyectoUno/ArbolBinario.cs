/*
 * Creado por SharpDevelop.
 * Usuario: Primo
 * Fecha: 18/8/2024
 * Hora: 17:17
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace proyectoUno
{
	/// <summary>
	/// Description of ArbolBinario.
	/// </summary>
	public class ArbolBinario<T>
	{
		private T dato;
		private ArbolBinario<T>hijoIzquierdo;
		private ArbolBinario<T>hijoDerecho;
		public int retardo; //nuevo atributo
		//modifico el constructor para incluir el retardo
		public ArbolBinario(T dato)
		{
			this.dato=dato;
			this.retardo=0;
		}
		//modifico el constructor para agegar el retardo al construir el arbol
		public ArbolBinario(T dato, int retardo=0)
		{
			this.dato=dato;
			this.retardo=retardo;
		}
		public T getDatoRaiz()
		{
			return this.dato;
		}
		public void setDatoRaiz(T nuevoDato)
		{this.dato=nuevoDato;}
		
		public ArbolBinario<T> getHijoIzquierdo()
		{
			return this.hijoIzquierdo;
		}
		public ArbolBinario<T> getHijoDerecho()
		{
			return this.hijoDerecho;
		}
		public void setRetardo(int retardo)
		{
			this.retardo=retardo;
		}
		public void agregarHijoIzquierdo(ArbolBinario<T> hijo)
		{
			hijoIzquierdo=hijo;
		}
		public void agregarHijoDerecho(ArbolBinario<T>hijo)
		{
			this.hijoDerecho=hijo;
		}
		public void eliminarHijoDerecho()
		{
			this.hijoDerecho=null;
		}
		public void eliminarHijoIzquierdo()
		{
			this.hijoIzquierdo=null;
		}
		public bool esHoja()
		{
			return hijoDerecho==null && hijoIzquierdo==null;
		}
		public void preorden() //raiz, hijo izq,hijo der
		{
			Console.WriteLine(this.dato + "");
			if(hijoIzquierdo!=null)
				hijoIzquierdo.preorden(); //llamo recursivamente al hijo izquierdo
			if(hijoDerecho!=null)
				hijoDerecho.preorden();
		}
		public void inorden() //hijo izq, raiz, hijo der
		{
			if(hijoIzquierdo!=null)
				hijoIzquierdo.inorden(); 
			Console.WriteLine(this.dato + "");
			if(hijoDerecho!=null)
				hijoDerecho.inorden();
		}
		public bool incluye(T elemento)
		{
			if (this.dato.ToString()==elemento.ToString())
			{return true;}
			if(hijoIzquierdo!=null && hijoIzquierdo.incluye(elemento))
			{return true;}
			if(hijoDerecho!=null && hijoDerecho.incluye(elemento))
			{return true;}
			else
				return false;
		}
		public void postorden() //hijo izq, hijo der, raiz
		{
			if(hijoIzquierdo!=null)
				hijoIzquierdo.postorden(); 
			if(hijoDerecho!=null)
				hijoDerecho.postorden();
			Console.WriteLine(this.dato + "");
		}
		public void recorridoPorNiveles()
		{
			Cola<ArbolBinario<T>> c=new Cola<ArbolBinario<T>>();
			ArbolBinario<T> arbolAux;
			c.encolar(this); //encola lo que haya en la raiz el arbol que llama el método
			while(!c.estaVacia())
			{
				arbolAux=c.desencolar();
				Console.WriteLine(arbolAux.dato + "");
				if(arbolAux.hijoIzquierdo!=null)
					c.encolar(arbolAux.hijoIzquierdo);
				if(arbolAux.hijoDerecho!=null)
					c.encolar(arbolAux.hijoDerecho);
			}
			
		}
		public void recorridoEntreNiveles(int n,int m)
		{
			if (n<0 || n>m )//verifico si los niveles son validos
			{	Console.WriteLine("rango inválido");
			return;
			}
			Cola<Tuple<ArbolBinario<T>,int >> c=new Cola<Tuple<ArbolBinario<T>,int>>();
			//encolar la raiz con nivel 0
			c.encolar(new Tuple<ArbolBinario<T>,int>(this,0));
			while(!c.estaVacia())
			{
				//desencolar el nodo y su nivel
				var par=c.desencolar();
				ArbolBinario<T> arbolAux=par.Item1;
				int nivel= par.Item2;
				//imprimir si el nodo esta entre los niveles n y m
				if(nivel>=n && nivel<=m)
					Console.WriteLine(arbolAux.dato + " ");
				if (arbolAux.hijoIzquierdo!=null)
				{
					c.encolar(new Tuple<ArbolBinario<T>,int>(arbolAux.hijoIzquierdo, nivel +1));
				}
				if (arbolAux.hijoDerecho!=null)
				{
					c.encolar(new Tuple<ArbolBinario<T>,int>(arbolAux.hijoDerecho, nivel +1));
				}
			}
		}
		public int contarHojas()
		{
			if(hijoIzquierdo==null && hijoDerecho==null)//sino tiene hijos retorna 1 
				return 1;
			int izq=0,der=0;//inicializo los  valores de las variables
			if(hijoIzquierdo!=null)
				izq=hijoIzquierdo.contarHojas();//llamo recursivamente al subarbol izq si existe
			if(hijoDerecho!=null)
				der=hijoDerecho.contarHojas();
			return izq+der; //retorno la suma de los valores acumulados de las variables
		}
		public ArbolBinario<int> nuevo(ArbolBinario<int>arbol)
		{
			if(arbol==null)
				return null;
			//el nuevo arbol se va construyendo tomando la raiz de arbol
			ArbolBinario<int> nuevoArbol=new ArbolBinario<int>(arbol.getDatoRaiz());
			
			if(arbol.getHijoIzquierdo()!=null)
			{//agrego hijo izquierdo al nuevo arbol llamando recursivamente a los hijos izq de arbol
				
				nuevoArbol.agregarHijoIzquierdo(nuevo(arbol.getHijoIzquierdo()));
				//ahora el hijo izquiero es el hijo izquierdo de arbol+el nodo padre
				nuevoArbol.getHijoIzquierdo().setDatoRaiz(nuevoArbol.getHijoIzquierdo().getDatoRaiz()+arbol.getDatoRaiz());
			}
			//hijo derecho agrego hijos derecho al nuevo arbol llamando recursivamente enviando el hijo derecho de arbol como atributo
			if(arbol.hijoDerecho!=null)
			{
				nuevoArbol.agregarHijoDerecho(nuevo(arbol.getHijoDerecho()));
			}
			return nuevoArbol; //obtengo el nuevo arbol
		}
		

	}
}
