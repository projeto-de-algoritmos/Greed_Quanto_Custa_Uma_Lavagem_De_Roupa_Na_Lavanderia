from fastapi import FastAPI
from Agenda.routers import Agenda	

app = FastAPI()

app.include_router(Agenda.router);