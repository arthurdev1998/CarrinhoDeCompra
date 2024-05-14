using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mongo.Services.CupomApi.Data;
using Mongo.Services.CupomApi.Dtos;
using Mongo.Services.CupomApi.Entities;
using Mongo.Services.CupomApi.Messages;

namespace Mongo.Services.CupomApi.Controllers;

[Route("api")]
[ApiController]
[Authorize]
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
    public async Task<List<CupomDto>> GetAllCupons()
    {
        var allCupons = await _db.Cupoms.ToListAsync();
        
        return _mapper.Map<List<CupomDto>>(allCupons);
    }

    [HttpGet("cupom/{id}")]
    public async Task<ResponseDto> GetCupomById(int id)
    {
        try
        {
            var obj = await _db.Cupoms.SingleOrDefaultAsync(x => x.Id == id);
            if (obj == default)
                throw new Exception("Id Duplicado ou inexistente");

            return new ResponseDto(_mapper.Map<CupomDto>(obj));
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ResponseDto(ex.Message);
        }
    }

    [HttpGet("cupom/GetByCode/{code}")]
    public async Task<ResponseDto> GetCupomByCode(string code)
    {
        try
        {
            var obj = await _db.Cupoms.FirstOrDefaultAsync(x => x.Code == code);
            if (obj == default)
                throw new Exception("Id Duplicado ou inexistente");

            return new ResponseDto(_mapper.Map<CupomDto>(obj));
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new(ex.Message);
        }
    }

    [HttpPost("cupom")]
    public async Task<ResponseDto> AddCupom([FromBody] CupomDto cupom)
    {
        try
        {
            var entity = _mapper.Map<Cupom>(cupom);
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            return new ResponseDto(cupom);
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ResponseDto(ex.Message);
        }
    }

    [HttpPut("cupom")]
    public async Task<ResponseDto> UpdateCupom([FromBody] CupomDto cupom)
    {
        try
        {
            var entity = _mapper.Map<Cupom>(cupom);
            _db.Update(entity);
            await _db.SaveChangesAsync();

            return new ResponseDto(cupom);
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ResponseDto(ex.Message);
        }
    }

    [HttpDelete("cupom/{Id}")]
    public async Task<ResponseDto> RemoveCupom(int id)
    {
        try
        {
            var entity = _db.Cupoms.OrderBy(x => x).FirstOrDefault(x => x.Id == id);

            if (entity == default)
                return new ResponseDto("Sem conteudo");

            _db.Remove(entity);
            await _db.SaveChangesAsync();

            return new ResponseDto();
        }

        catch (Exception ex)
        {
            return new ResponseDto(ex.Message);
        }
    }
}