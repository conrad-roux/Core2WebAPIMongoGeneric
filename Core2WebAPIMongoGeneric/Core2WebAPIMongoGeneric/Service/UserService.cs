using Core2WebAPIMongoGeneric.Interface;
using Core2WebAPIMongoGeneric.Models;
using Core2WebAPIMongoGeneric.Repo;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core2WebAPIMongoGeneric.Service
{
    public class UserService : IService<User>
    {
        private MongoRepo<User> _repo;

        public UserService()
        {
            _repo = new MongoRepo<User>("users");
        }

        public IEnumerable<string> Get(Expression<Func<User, bool>> query)
        {
            var list = _repo.Find(query);
            yield return JsonConvert.SerializeObject(list.Result);
        }

        public User GetUser(Expression<Func<User, bool>> query)
        {
            var list = _repo.Find(query);
            if (list.Result.Count != 0)
                return list.Result[0];
            else
                return null;
        }

        public string GetById(Expression<Func<User, bool>> query)
        {
            var list = _repo.Find(query);
            return JsonConvert.SerializeObject(list.Result);
        }

        public string Create(User user)
        {
            if (user != null)
            {
                if (Count(u => u.Email == user.Email) == 0)
                {
                    //this user email does not exist. Please add them
                    var newUser = new User
                    {
                        Name = user.Name,
                        LastName = user.LastName,
                        Email = user.Email
                    };

                    return _repo.Add(newUser).IsCompleted.ToString();
                }
                else
                {
                    return "Email address already in use";
                }
            }
            else
            {
                return "no user to insert";
            }
        }

        public string Update(string id, User user)
        {
            if (user != null)
            {
                var updateUser = new User
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email
                };

                //update command want 2 params
                //query
                //builder
                var update = Builders<User>.Update
                    .Set(u => u.Email, updateUser.Email)
                    .Set(u => u.Name, updateUser.Name);
                return _repo.Update(u => u.Id == id, update).IsCompleted.ToString();
            }
            else
            {
                //this is not valid model and is null
                return "";
            }
        }

        public string Delete(string id)
        {
            _repo.Delete(x => x.Id == id);
            return "";
        }

        public long Count(Expression<Func<User, bool>> query)
        {
            return _repo.Count(query).Result;
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
