using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Shared.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        [Key]
        public long Id { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAtualizacao { get; set; }



        public Entity()
        {
            DataCadastro = DateTime.Now;
        }

        public bool Equals(Entity other) => Id == other.Id;
    }
}
