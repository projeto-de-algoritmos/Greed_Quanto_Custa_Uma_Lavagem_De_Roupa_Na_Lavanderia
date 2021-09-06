from fastapi import HTTPException, status
import matplotlib.pyplot as plt
from Agenda import schemas
import pandas as pd
import random
import numpy as np
from io import BytesIO
from base64 import b64encode
import pyimgur

def plotar(request: schemas.Dia):
	CLIENT_ID = "Secret"
	PATH = './Auxiliar.png'
	try:

		def randomColor():
			return(random.randrange(50)/100 + 0.5, random.randrange(50)/100 + 0.5, random.randrange(50)/100 + 0.5);

		df = pd.DataFrame({"begin": request.inicios, "end" : request.duracoes })

		cont =0.5

		fig, ax = plt.subplots()
		ax.add_patch(plt.Rectangle((0,0.5-0.025), 24, 0.05, facecolor=(0.7,0.7,0.7), edgecolor=(0,0,0)))
		for x_1 , x_2 in zip(df['begin'].values ,df['end'].values + df['begin'].values):
		    ax.add_patch(plt.Rectangle((x_1,cont-0.025),x_2-x_1, 0.05, facecolor=randomColor(), edgecolor=(0,0,0)))
		    #cont += 0.1

		plt.title("Agenda do dia")
		plt.xlabel("Horas")
		fig.canvas.manager.set_window_title('Agenda')
		ax.axes.get_xaxis().set_ticks(range(25))
		ax.axes.get_yaxis().set_visible(False)
		ax.autoscale()
		ax.set_ylim(0,1)
		plt.grid(color = 'black', linestyle = '--', linewidth = 1)
		figfile = BytesIO()
		plt.savefig(figfile, format='png')
		figfile.seek(0)  # rewind to beginning of file#figdata_png = base64.b64encode(figfile.read())
		data = b64encode(figfile.read())
		client = pyimgur.Imgur(CLIENT_ID)
		r = client._send_request('https://api.imgur.com/3/image', method='POST', params={'image': data})
		return r['link']
	except:
		return "ERROR"