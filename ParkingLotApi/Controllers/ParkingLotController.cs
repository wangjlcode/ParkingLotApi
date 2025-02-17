﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("/parkinglots")]
    public class ParkingLotController : Controller
    {
        private readonly ParkingLotService _parkingLotService;
        public ParkingLotController(ParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {

            return Created(nameof(AddParkingLotAsync), await _parkingLotService.AddAsync(parkingLotDto));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParkingLotByIdAsync(string id)
        {
            await _parkingLotService.DeleteParkingLotByIdAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotByPageAsync([FromQuery]int pageIndex)
        {
            return Ok(await _parkingLotService.GetParkingLotByPageAsync(pageIndex));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingLot>> UpdateParkingLotAsync([FromQuery] int capacity, string id)
        {
            return Ok(await _parkingLotService.UpdateParkingLotCapacity(id, capacity));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotByIdAsync(string id)
        {
            return Ok(await _parkingLotService.GetParkingLotByIdAsync(id));
        }
    }
}
