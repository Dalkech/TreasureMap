using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUseCase<TRequest,TResponse>
    {
        public abstract TResponse Handle(TRequest request);
    }
}
