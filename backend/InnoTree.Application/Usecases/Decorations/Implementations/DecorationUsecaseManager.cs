using AutoMapper;
using InnoTree.Application.Usecases.Decorations.Interfaces;
using InnoTree.Core.Repositories.Interfaces;

namespace InnoTree.Application.Usecases.Decorations.Implementations;

public class DecorationUsecaseManager : IDecorationUsecaseManager
{
	private readonly Lazy<ICreateDecorationUsecase> _createDecorationUsecase;
	private readonly Lazy<IDeleteDecorationUsecase> _deleteDecorationUsecase;
	private readonly Lazy<IGetAllDecorationsUsecase> _getAllDecorationsUsecase;
	private readonly Lazy<IGetDecorationByIdUsecase> _getDecorationByIdUsecase;
	private	readonly Lazy<IUpdateDecorationUsecase> _updateDecorationUsecase;

	public ICreateDecorationUsecase CreateDecorationUsecase => _createDecorationUsecase.Value;

	public IDeleteDecorationUsecase DeleteDecorationUsecase => _deleteDecorationUsecase.Value;

	public IGetAllDecorationsUsecase GetAllDecorationsUsecase => _getAllDecorationsUsecase.Value;

	public IGetDecorationByIdUsecase GetDecorationByIdUsecase => _getDecorationByIdUsecase.Value;

	public IUpdateDecorationUsecase UpdateDecorationUsecase => _updateDecorationUsecase.Value;

    public DecorationUsecaseManager(
		IUnitOfWork unitOfWork, 
		IMapper mapper)
    {
		_createDecorationUsecase = new Lazy<ICreateDecorationUsecase>(() => new CreateDecorationUsecase(unitOfWork, mapper));
		_deleteDecorationUsecase = new Lazy<IDeleteDecorationUsecase>(() => new DeleteDecorationUsecase(unitOfWork, mapper));
		_getAllDecorationsUsecase = new Lazy<IGetAllDecorationsUsecase>(() => new GetAllDecorationsUsecase(unitOfWork, mapper));
		_getDecorationByIdUsecase = new Lazy<IGetDecorationByIdUsecase>(() => new GetDecorationByIdUsecase(unitOfWork, mapper));
		_updateDecorationUsecase = new Lazy<IUpdateDecorationUsecase>(() => new UpdateDecorationUsecase(unitOfWork, mapper));
    }
}
