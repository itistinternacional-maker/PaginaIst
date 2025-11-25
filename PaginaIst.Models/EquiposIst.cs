using System;
using System.ComponentModel.DataAnnotations; // ✅ Espacio de nombres para validaciones y metadatos

namespace PaginaIst.Models
    {
    public class EquiposIst
        {
        // ✅ Clave primaria (PK) del modelo
        [Key]
        public int id { get; set; }

        // ✅ Campo obligatorio con mensaje personalizado
        [Required ( ErrorMessage = "El nombre Placa es obligatoria" )]
        [Display ( Name = "Placa" )]
        public int Placa { get; set; }

        // ✅ Campo obligatorio para el ID del empleado
        [Required ( ErrorMessage = "La Id empleado es obligatoria" )]
        [Display ( Name = "Id_Empleado" )]
        public int Id_Empleado { get; set; }

        // ✅ Campo obligatorio para el Hostname
        [Required ( ErrorMessage = "El Hostname es obligatorio" )]
        [Display ( Name = "Hostname" )]
        public string Hostname { get; set; }

        // ✅ Fecha Inicial (Campo obligatorio)
        [Required ( ErrorMessage = "La Fecha es obligatoria" )]
        [Display ( Name = "Fecha Inicial" )]
        public DateTime? Fecha_Inicial { get; set; }  // ⚠️ `DateTime?` permite valores nulos

        // ✅ Fecha Final (Campo opcional)
        [Display ( Name = "Fecha Final" )]
        public DateTime? Fecha_Final { get; set; }

        // ✅ Campo obligatorio para el Tipo de Equipo
        [Required ( ErrorMessage = "El Id tipo equipo es obligatorio" )]
        [Display ( Name = "Id tipo equipo" )]
        public int Id_Tipoequipo { get; set; }

        // ✅ Campo obligatorio para la marca
        [Required ( ErrorMessage = "La marca es obligatoria" )]
        [Display ( Name = "Marca" )]
        public string Marca { get; set; }

        // ✅ Campo obligatorio para el modelo
        [Required ( ErrorMessage = "El modelo es obligatorio" )]
        [Display ( Name = "Modelo" )]
        public string Modelo { get; set; }

        // ✅ Campo obligatorio para el serial
        [Required ( ErrorMessage = "El serial es obligatorio" )]
        [Display ( Name = "N° Serial" )]
        public string Serial { get; set; }

        // ✅ ⚠️ **Campo `Nit_Proveedor` potencialmente problemático**
        [Display ( Name = "Nit proveedor" )]
        public int Nit_Proveedor { get; set; }  // ⚠️ Cambiar a `string` si es necesario

        // ✅ Garantía (Opcional)
        [Display ( Name = "Garantía en años" )]
        public int Garantia { get; set; }

        // ✅ Fuente o cargador (Opcional)
        [Display ( Name = "Fuente o Cargador" )]
        public string Fuente { get; set; }

        // ✅ Capacidad de la fuente (Opcional)
        [Display ( Name = "Capacidad de Fuente" )]
        public string Capacidad_Fuente { get; set; }

        // ✅ Procesador (Obligatorio)
        [Required ( ErrorMessage = "El procesador es obligatorio" )]
        [Display ( Name = "Procesador" )]
        public string Procesador { get; set; }

        // ✅ Clase de Disco N°1 (Obligatorio)
        [Required ( ErrorMessage = "La clase de disco N°1 es obligatoria" )]
        [Display ( Name = "Clase Disco N°1" )]
        public string Clase_DiscoN1 { get; set; }

        // ✅ Capacidad del Disco N°1 (Obligatorio)
        [Required ( ErrorMessage = "Capacidad disco N°1 es obligatoria" )]
        [Display ( Name = "Capacidad Disco N°1" )]
        public int Capacidad_Disco_N1 { get; set; }

        // ✅ Clase de Disco N°2 (Obligatorio)
        [Required ( ErrorMessage = "La clase de disco N°2 es obligatoria" )]
        [Display ( Name = "Clase Disco N°2" )]
        public string Clase_Disco_N2 { get; set; }

        // ✅ Capacidad del Disco N°2 (Obligatorio)
        [Required ( ErrorMessage = "Capacidad disco N°2 es obligatoria" )]
        [Display ( Name = "Capacidad Disco N°2" )]
        public int Capacidad_Disco_N2 { get; set; }

        // ✅ Capacidad RAM N°1 (Obligatoria)
        [Required ( ErrorMessage = "Capacidad RAM N°1 es obligatoria" )]
        [Display ( Name = "Capacidad RAM N°1" )]
        public int MEMORIA_RAM_N1 { get; set; }

        // ✅ Capacidad RAM N°2 (Obligatoria)
        [Required ( ErrorMessage = "Capacidad RAM N°2 es obligatoria" )]
        [Display ( Name = "Capacidad RAM N°2" )]
        public int MEMORIA_RAM_N2 { get; set; }
        }
    }
