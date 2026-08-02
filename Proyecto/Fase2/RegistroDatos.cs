using System;

namespace DataCore
{
    /// <summary>
    /// Struct inmutable que representa un registro de datos.
    /// REUTILIZADO de la Fase 1 - NO MODIFICAR.
    /// </summary>
    public readonly struct RegistroDatos : IEquatable<RegistroDatos>
    {
        public int Id { get; }
        public long HashValidation { get; }
        public int PesoBytes { get; }

        public RegistroDatos(int id, long hash, int pesoBytes)
        {
            if (pesoBytes <= 0)
                throw new ArgumentException(
                    "PesoBytes debe ser mayor a 0. Un registro no puede tener tamaño nulo o negativo.",
                    nameof(pesoBytes));

            Id = id;
            HashValidation = hash;
            PesoBytes = pesoBytes;
        }

        public bool Equals(RegistroDatos other)
            => Id == other.Id && HashValidation == other.HashValidation && PesoBytes == other.PesoBytes;

        public override bool Equals(object? obj)
            => obj is RegistroDatos other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Id, HashValidation, PesoBytes);

        public override string ToString()
            => $"Id: {Id,4} | Hash: {HashValidation,20} | Peso: {PesoBytes,4} bytes";

        public static bool operator ==(RegistroDatos left, RegistroDatos right)
            => left.Equals(right);

        public static bool operator !=(RegistroDatos left, RegistroDatos right)
            => !(left == right);
    }
}