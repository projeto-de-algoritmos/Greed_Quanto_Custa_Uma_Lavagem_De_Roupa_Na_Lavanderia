from fastapi import APIRouter, status, HTTPException
from Agenda.repository import Agenda
from Agenda import schemas

router = APIRouter(
	prefix="/Agenda",
	tags=['Agenda']
)

@router.post('/', status_code=status.HTTP_201_CREATED)
def plotar(request: schemas.Dia):
	return Agenda.plotar(request);