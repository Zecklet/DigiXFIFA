/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.service;

import java.io.IOException;
import java.io.StringReader;
import javax.swing.text.Document;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;

/**
 *
 * @author Jorge
 */
public class LectorXML {

    public Document LeerXML(String pArchivoXML) throws ParserConfigurationException, IOException, SAXException {
        DocumentBuilderFactory mFactory = DocumentBuilderFactory.newInstance();
        DocumentBuilder mBuilder = mFactory.newDocumentBuilder();
        Document mDocument = (Document) mBuilder.parse(new InputSource(new StringReader(pArchivoXML)));
        mDocument.toString();
        return  mDocument;
    }
    
}
