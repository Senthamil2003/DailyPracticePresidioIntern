from PyPDF2 import PdfWriter, PdfReader
from reportlab.pdfgen import canvas
from reportlab.lib.pagesizes import letter
from reportlab.pdfbase import pdfmetrics
from reportlab.pdfbase.ttfonts import TTFont
from io import BytesIO
import os

def add_data_to_pdf(name,mail,age,dateofBirth,role):
    pdf_path="datastore.pdf"
    reader = PdfReader(pdf_path)
    
    # Extract all text from the PDF
    existing_text = ""
    for page in reader.pages:
        existing_text += page.extract_text()+"\n"
    print(existing_text)
    if(len(existing_text.strip())==0):
        existing_text+="Name-Age-DaateOfBirth-mail-role\n"
        
  
    combined_text = existing_text.strip() + "\n" + f"{name}.{mail}.{age}.{dateofBirth}.{role}"
    
   
    packet = BytesIO()
    can = canvas.Canvas(packet, pagesize=letter)
    
   
    pdfmetrics.registerFont(TTFont('Arial', 'Arial.ttf'))
    can.setFont("Arial", 12)
    

    textobject = can.beginText()
    textobject.setTextOrigin(50, 750) 
    for line in combined_text.split('\n'):
        textobject.textLine(line)
    can.drawText(textobject)
    
    can.save()
    packet.seek(0)
    new_pdf = PdfReader(packet)
    
    
    writer = PdfWriter()
    writer.add_page(new_pdf.pages[0])
    
  
    temp_file = pdf_path + ".tmp"
    
   
    with open(temp_file, "wb") as output_file:
        writer.write(output_file)
    

    os.replace(temp_file, pdf_path)

