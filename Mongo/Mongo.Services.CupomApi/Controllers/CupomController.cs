using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mongo.Services.CupomApi.Data;
using Mongo.Services.CupomApi.Dtos;
using Mongo.Services.CupomApi.Entities;
using Mongo.Services.CupomApi.Messages;

namespace Mongo.Services.CupomApi.Controllers;

[Route("api")]
public class CupomController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public CupomController(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet("cupom")]
    public async Task<IEnumerable<CupomDto>> GetAllCupons()
    {
        try
        {
           IEnumerable<Cupom> cupomList = await _db.Cupoms.ToListAsync();
           return _mapper.Map<IEnumerable<CupomDto>>(cupomList);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("cupom/{id}")]
    public async Task<ServiceResult<CupomDto>> GetCupomById(int id)
    {
        try
        {
            var obj = await _db.Cupoms.SingleOrDefaultAsync(x => x.Id == id);
            if(obj == default)
                throw new Exception("Id Duplicado ou inexistente");

            return new ServiceResult<CupomDto>(_mapper.Map<CupomDto>(obj));
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ServiceResult<CupomDto>(ex.Message);
        }
    }

    [HttpGet("cupom/code")]
    public async Task<ServiceResult<CupomDto>> GetCupomByCode(string code)
    {
        try
        {
            var obj = await _db.Cupoms.FirstOrDefaultAsync(x => x.Code == code);
            if(obj == default)
                throw new Exception("Id Duplicado ou inexistente");

            return new ServiceResult<CupomDto>(_mapper.Map<CupomDto>(obj));
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ServiceResult<CupomDto>(ex.Message);
        }
    }

    [HttpPost("cupom")]
    public async Task<ServiceResult<CupomDto>> AddCupom([FromBody]CupomDto cupom)
    {
        try
        {
            var entity = _mapper.Map<Cupom>(cupom);
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            return new ServiceResult<CupomDto>(cupom);
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ServiceResult<CupomDto>(ex.Message);
        }
    }

    [HttpPut("cupom")]
    public async Task<ServiceResult<CupomDto>> UpdateCupom([FromBody]CupomDto cupom)
    {
        try
        {
            var entity = _mapper.Map<Cupom>(cupom);
             _db.Update(entity);
            await _db.SaveChangesAsync();

            return new ServiceResult<CupomDto>(cupom);
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ServiceResult<CupomDto>(ex.Message);
        }
    }

    [HttpDelete("cupom/{Id}")]
    public async Task<ServiceResult> RemoveCupom(int id)
    {
        try
        {
            var entity = _db.Cupoms.OrderBy(x => x).FirstOrDefault(x => x.Id == id);

            if(entity == default)
                return new ServiceResult("Sem conteudo");

            _db.Remove(entity);
            await _db.SaveChangesAsync();

            return new ServiceResult();
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ServiceResult<CupomDto>(ex.Message);
        }
    }
}