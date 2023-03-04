using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.CustomerOperations.Queries.GetUserDetail
{
    public class GetUserDetailQuery
    {
        public int UserId { get; set; }
        public readonly IMovieStoreDbContext _contex;
        public readonly IMapper _mapper;
        public GetUserDetailQuery(IMovieStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public UserDetailViewModel Handle()
        {
            var user = _contex.Customers.SingleOrDefault(x => x.Id == UserId );
            if(user is null)
            {
                throw new InvalidOperationException("Kulannıcı Bulunamadi.");
            }
            return _mapper.Map<UserDetailViewModel>(user);
        }
    }
    public class UserDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

}