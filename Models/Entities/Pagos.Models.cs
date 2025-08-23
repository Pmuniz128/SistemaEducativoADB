﻿using System;

namespace SistemaEducativoADB.API.Models.Entities
{
    public class Pago
    {
        public int IdPago { get; set; }              // PK (IDENTITY)
        public int IdEstudiante { get; set; }        // FK a ESTUDIANTE
        public decimal Monto { get; set; }           // Monto del pago
        public DateTime Fecha { get; set; }          // Fecha del pago
        public string Estado { get; set; } = "";     // "Pendiente" | "Pagado"
        public string MetodoPago { get; set; } = ""; // "Tarjeta" | "Transferencia" | "Efectivo"

        // Navegación (opcional)
        public Estudiante? Estudiante { get; set; }
    }
}
