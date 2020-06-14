using System;
using System.Collections.Generic;
using System.Text;

namespace FuntionalLinq
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public Task(int id, string name, int userId)
        {
            Id = id;
            Name = name;
            UserId = userId;
        }

        public static List<Task> Tasks()
        {
            return new List<Task> 
            {
                new Task (1, "Limpiar", 1),
                new Task (2, "Cocinar", 2),
                new Task (3, "Comprar comida", 2),
                new Task (4, "Pagar servicios", 3),
                new Task (5, "Arreglar el pc", 4),
                new Task (6, "Sacar el perro", 5),
                new Task (7, "Comprobar si todo esta en orden", 5),
                new Task (8, "Arrendar la finca", 6),
                new Task (9, "Comprar la bebida", 1),
                new Task (10, "Preparar el carro", 7),
                new Task (11, "Llevar la musica", 7),
                new Task (12, "Hacer la lista de invitados", 1),
            };
        }
    }
}
