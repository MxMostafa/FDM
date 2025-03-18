global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using Client.Domain.Enums;
global using Client.Domain.Dtos;
global using Client.Domain.Dtos.Response;
global using Client.Domain.Entites;
global using Microsoft.Extensions.DependencyInjection;
global using Client.Domain.Interfaces.Services;
global using Client.Domain.Interfaces.Repositories;

global using Client.Domain.Dtos.Response.AppSetting;
global using Client.Domain.Dtos.Response.DownloadQueueItem;

global using Client.Application.Models;
global using Client.Domain.Dtos.Request.DownloadFile;
global using Client.Domain.EventModels;
global using Microsoft.Extensions.Logging;
global using Client.Domain.Dtos.Response.ChunkFile;
global using Client.Domain.Interfaces.General.Errors;
global using MapsterMapper;
global using System.Net.Http.Headers;