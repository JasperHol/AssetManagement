using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Amenities;


public record Number(int Value)
{
    public class Create
    {
        private int value;

        public Create(int value)
        {
            this.value = value;
        }

        public Number Value { get; set; }
    }
}