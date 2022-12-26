using Backend.Context;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Backend.Repositories
{
    public class GuestBookRepository : IRepository
    {
        public IConfiguration _configuration;
        private readonly MyContext context;
        public GuestBookRepository(IConfiguration configuration, MyContext context)
        {
            _configuration = configuration;
            this.context = context;
        }

        DynamicParameters parameters = new DynamicParameters();
        public IEnumerable<GuestBookModel> Get()
        {
            using (SqlConnection connection = new SqlConnection(_configuration
                ["ConnectionStrings:APIDapper"]))
            {
                var spName = "SP_GetAllDataGuestBooks";
                var book = connection.Query<GuestBookModel>(spName, commandType:CommandType.StoredProcedure);
                return book;
            }
        }

        public GuestBookModel Get(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:APIDapper"]))
            {
                var procName = "dbo.SP_GetIdDataGuestBooks";
                parameters.Add("@Id", Id);
                var getId = connection.QuerySingleOrDefault<GuestBookModel>(procName, parameters, commandType: CommandType.StoredProcedure);
                return getId;

            }
        }

        public int Insert(GuestBookModel guestBookModel)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:APIDapper"]))
            {
                var procName = "SP_InsertDataGuestBooks";
                parameters.Add("@Nama", guestBookModel.Nama);
                parameters.Add("@No_Hp", guestBookModel.No_Hp);
                parameters.Add("@Email", guestBookModel.Email);
                parameters.Add("@Alamat", guestBookModel.Alamat);
                parameters.Add("@Provinsi", guestBookModel.Provinsi);
                parameters.Add("@Kota_Kabupaten", guestBookModel.Kota_Kabupaten);
                parameters.Add("@Kecamatan", guestBookModel.Kecamatan);
                parameters.Add("@Kelurahan", guestBookModel.Kelurahan);
                parameters.Add("@Kode_Pos", guestBookModel.Kode_Pos);
                parameters.Add("@Kehadiran", DateTime.Now);
                var insert = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }
        }

        public int Update(GuestBookModel guestBookModel, int Id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:APIDapper"]))
            {
                var procName = "dbo.SP_UpdateDataGuestBooks";
                parameters.Add("@Id", Id);
                parameters.Add("@Nama", guestBookModel.Nama);
                parameters.Add("@No_Hp", guestBookModel.No_Hp);
                parameters.Add("@Email", guestBookModel.Email);
                parameters.Add("@Alamat", guestBookModel.Alamat);
                parameters.Add("@Provinsi", guestBookModel.Provinsi);
                parameters.Add("@Kota_Kabupaten", guestBookModel.Kota_Kabupaten);
                parameters.Add("@Kecamatan", guestBookModel.Kecamatan);
                parameters.Add("@Kelurahan", guestBookModel.Kelurahan);
                parameters.Add("@Kode_Pos", guestBookModel.Kode_Pos);
                var update = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return update;
            }
        }

        public int Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration
                ["ConnectionStrings:APIDapper"]))
            {
                var spName = "SP_DeleteDataGuestBooks";
                parameters.Add("@Id", Id);
                var delete = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
                return delete;
            }
        }
    }
}
