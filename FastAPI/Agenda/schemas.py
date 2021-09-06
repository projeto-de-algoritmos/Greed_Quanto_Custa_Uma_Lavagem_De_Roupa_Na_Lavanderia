from pydantic import BaseModel
from typing import List

class Dia(BaseModel):
	inicios: List[float] = []
	duracoes: List[float] = []