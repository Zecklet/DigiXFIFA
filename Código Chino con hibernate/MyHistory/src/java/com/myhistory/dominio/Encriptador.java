/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.dominio;

import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.security.KeyFactory;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.PublicKey;
import java.security.PrivateKey;
import java.security.spec.PKCS8EncodedKeySpec;
import java.security.spec.X509EncodedKeySpec;
import sun.misc.BASE64Decoder;
import sun.misc.BASE64Encoder;
import javax.crypto.Cipher;

/**
 *
 * @author Kenneth
 */
public class Encriptador {

    //COLOCAR EN CONSTANTES
    private static final String kAlgoritmo = "RSA";
    private static final int kTamanoLlave = 1024;
    private static final String kTransformation = "RSA/ECB/PKCS1Padding";
    private static final String kCharSetUsado = "UTF8";

    public Encriptador() throws Exception {
    }

    public void GenerarLlaves(String pDireccionLlavePrivada,
            String pDireccionLlavePublica) throws Exception {
        KeyPairGenerator mKeyGen = KeyPairGenerator.getInstance(kAlgoritmo);
        mKeyGen.initialize(kTamanoLlave);
        KeyPair keyPair = mKeyGen.generateKeyPair();
        byte[] mBytesLlavePublica = keyPair.getPublic().getEncoded();
        FileOutputStream mArchivoEscritua = new FileOutputStream(pDireccionLlavePublica);
        mArchivoEscritua.write(mBytesLlavePublica);
        mArchivoEscritua.close();
        byte[] BytesLlavePrivada = keyPair.getPrivate().getEncoded();
        mArchivoEscritua = new FileOutputStream(pDireccionLlavePrivada);
        mArchivoEscritua.write(BytesLlavePrivada);
        mArchivoEscritua.close();
    }

    private PublicKey obtenerLlavePublica(String pDireccion)
            throws Exception {

        File mArchivo = new File(pDireccion);
        FileInputStream mArchivoEntrada = new FileInputStream(mArchivo);
        DataInputStream mDatosEntrada = new DataInputStream(mArchivoEntrada);
        byte[] BytesLlave = new byte[(int) mArchivo.length()];
        mDatosEntrada.readFully(BytesLlave);
        mDatosEntrada.close();
        X509EncodedKeySpec mSpec
                = new X509EncodedKeySpec(BytesLlave);
        KeyFactory mKeyFactory = KeyFactory.getInstance(kAlgoritmo);
        return mKeyFactory.generatePublic(mSpec);
    }

    private PrivateKey ObtenerLlavePrivada(String pDireccion)
            throws Exception {

        File mArchivo = new File(pDireccion);
        FileInputStream mArchivoEntrada = new FileInputStream(mArchivo);
        DataInputStream mDatosEntrada = new DataInputStream(mArchivoEntrada);
        byte[] mBytesllave = new byte[(int) mArchivo.length()];
        mDatosEntrada.readFully(mBytesllave);
        mDatosEntrada.close();
        PKCS8EncodedKeySpec mSpec
                = new PKCS8EncodedKeySpec(mBytesllave);
        KeyFactory mKeyFactory = KeyFactory.getInstance(kAlgoritmo);
        return mKeyFactory.generatePrivate(mSpec);
    }

    public String Encriptar(String pTexto, String pDireccionLlavePublica) throws Exception {
        PublicKey mLlavePublica = obtenerLlavePublica(pDireccionLlavePublica);
        Cipher mCipher = Cipher.getInstance(kTransformation);
        mCipher.init(Cipher.ENCRYPT_MODE, mLlavePublica);
        byte[] mTextoEncriptado = mCipher.doFinal(pTexto.getBytes(kCharSetUsado));
        return EncodeBASE64(mTextoEncriptado);
    }

    public String Desencriptar(String pTextoEncriptado, String pDireccionLlavePrivada) throws Exception {
        PrivateKey mLlavePrivada = ObtenerLlavePrivada(pDireccionLlavePrivada);
        Cipher mCipher = Cipher.getInstance(kTransformation);
        mCipher.init(Cipher.DECRYPT_MODE, mLlavePrivada);
        byte[] mTexto = mCipher.doFinal(DecodeBASE64(pTextoEncriptado));
        return new String(mTexto, kCharSetUsado);
    }

    private String EncodeBASE64(byte[] pBytes) {
        BASE64Encoder mEncoder = new BASE64Encoder();
        return mEncoder.encode(pBytes);
    }

    private byte[] DecodeBASE64(String pTexto) throws Exception {
        BASE64Decoder mEncoder = new BASE64Decoder();
        return mEncoder.decodeBuffer(pTexto);
    }
}
