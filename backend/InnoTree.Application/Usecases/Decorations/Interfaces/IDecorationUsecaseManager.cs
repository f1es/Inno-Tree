namespace InnoTree.Application.Usecases.Decorations.Interfaces;

public interface IDecorationUsecaseManager
{
	public ICreateDecorationUsecase CreateDecorationUsecase { get; }
	public IDeleteDecorationUsecase DeleteDecorationUsecase { get; }
	public IGetAllDecorationsUsecase GetAllDecorationsUsecase { get; }
	public IGetDecorationByIdUsecase GetDecorationByIdUsecase { get; }
	public IUpdateDecorationUsecase UpdateDecorationUsecase { get; }
}
