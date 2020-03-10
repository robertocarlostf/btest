using Bertoni.Data.Abstraction;
using Bertoni.Data.Entitites;
using Bertoni.Domain.Abstraction;
using Bertoni.Domain.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni.Domain
{
    public class PhotoService : IService<Photo>
    {
        private IRepository<Photos> _PhotoRepo = null;

        public PhotoService(IRepository<Photos> _PhotoRepository)
        {
            _PhotoRepo = _PhotoRepository;
        }

        public IList<Photo> GetAll()
        {
            List<Photo> _return = null;

            try
            {
                var _data = _PhotoRepo.GetAll();

                if(_data != null)
                {
                    _return = new List<Photo>();
                    foreach (var d in _data)
                    {
                        _return.Add(new Photo(d));
                    }
                }


                return _return;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Photo GetById(int id)
        {
            try
            {
                var _data = _PhotoRepo.Get(id);
                return new Photo(_data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Photo> QueryBy(Func<Photo, bool> filter)
        {
            List<Photo> _return = null;

            try
            {
                var _data = _PhotoRepo.GetAll();
                if(_data != null)
                {
                    _return = new List<Photo>();

                    foreach (var d in _data)
                    {
                        _return.Add(new Photo(d));
                    }
                }

                return _return.Where(filter).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
