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
    public class AlbumService : IService<Album>
    {
        private IRepository<Albums> _albumRepo = null;

        public AlbumService(IRepository<Albums> _albumRepository)
        {
            _albumRepo = _albumRepository;
        }

        public IList<Album> GetAll()
        {
            List<Album> _return = null;

            try
            {
                var _data = _albumRepo.GetAll();

                if(_data != null)
                {
                    _return = new List<Album>();
                    foreach (var d in _data)
                    {
                        _return.Add(new Album(d));
                    }
                }


                return _return;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Album GetById(int id)
        {
            try
            {
                var _data = _albumRepo.Get(id);
                return new Album(_data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Album> QueryBy(Func<Album, bool> filter)
        {
            List<Album> _return = null;

            try
            {
                var _data = _albumRepo.GetAll();
                if(_data != null)
                {
                    _return = new List<Album>();

                    foreach (var d in _data)
                    {
                        _return.Add(new Album(d));
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
