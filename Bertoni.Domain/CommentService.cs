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
    public class CommentService : IService<Comment>
    {
        private IRepository<Comments> _CommentRepo = null;

        public CommentService(IRepository<Comments> _CommentRepository)
        {
            _CommentRepo = _CommentRepository;
        }

        public IList<Comment> GetAll()
        {
            List<Comment> _return = null;

            try
            {
                var _data = _CommentRepo.GetAll();

                if(_data != null)
                {
                    _return = new List<Comment>();
                    foreach (var d in _data)
                    {
                        _return.Add(new Comment(d));
                    }
                }


                return _return;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Comment GetById(int id)
        {
            try
            {
                var _data = _CommentRepo.Get(id);
                return new Comment(_data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Comment> QueryBy(Func<Comment, bool> filter)
        {
            List<Comment> _return = null;

            try
            {
                var _data = _CommentRepo.GetAll();
                if(_data != null)
                {
                    _return = new List<Comment>();

                    foreach (var d in _data)
                    {
                        _return.Add(new Comment(d));
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
