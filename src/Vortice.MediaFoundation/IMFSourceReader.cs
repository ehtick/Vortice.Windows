﻿// Copyright (c) Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using SharpGen.Runtime.Win32;

namespace Vortice.MediaFoundation;

public unsafe partial class IMFSourceReader
{
    internal IMFByteStream? _byteStream;

    /// <summary>	
    /// <p><strong>Applies to: </strong>desktop apps | Metro style apps</p><p>Gets a format that is supported natively by the media source.</p>	
    /// </summary>	
    /// <param name="readerIndex"><dd> <p>Specifies which stream to query. The value can be any of the following.</p> <table> <tr><th>Value</th><th>Meaning</th></tr> <tr><td> <dl> <dt>0?0xFFFFFFFB</dt> </dl> </td><td> <p>The zero-based index of a stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstVideoStream"/></strong></strong></dt> <dt>0xFFFFFFFC</dt> </dl> </td><td> <p>The first video stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstAudioStream"/></strong></strong></dt> <dt>0xFFFFFFFD</dt> </dl> </td><td> <p>The first audio stream.</p> </td></tr> </table> <p>?</p> </dd></param>	
    /// <param name="dwMediaTypeIndex"><dd> <p>The zero-based index of the media type to retrieve.</p> </dd></param>	
    /// <returns><dd> <p>Receives a reference to the <strong><see cref="IMFMediaType"/></strong> interface. The caller must release the interface.</p> </dd></returns>	
    /// <remarks>	
    /// <p>This method queries the underlying media source for its native output format. Potentially, each source stream can produce more than one output format. Use the <em>dwMediaTypeIndex</em> parameter to loop through the available formats. Generally, file sources offer just one format per stream, but capture devices might offer several formats.</p><p> The method returns a copy of the media type, so it is safe to modify the object received in the <em> ppMediaType</em> parameter.</p><p>To set  the output type for a stream, call the <strong><see cref="SetCurrentMediaType(int, IMFMediaType)"/></strong> method.</p><p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
    /// </remarks>	
    /// <msdn-id>dd374661</msdn-id>	
    /// <unmanaged>HRESULT IMFSourceReader::GetNativeMediaType([In] unsigned int dwStreamIndex,[In] unsigned int dwMediaTypeIndex,[Out] IMFMediaType** ppMediaType)</unmanaged>	
    /// <unmanaged-short>IMFSourceReader::GetNativeMediaType</unmanaged-short>	
    public IMFMediaType GetNativeMediaType(SourceReaderIndex readerIndex, int dwMediaTypeIndex)
    {
        return GetNativeMediaType((int)readerIndex, dwMediaTypeIndex);
    }

    /// <summary>	
    /// <p><strong>Applies to: </strong>desktop apps | Metro style apps</p><p>Selects or deselects one or more streams.</p>	
    /// </summary>	
    /// <param name="readerIndex"><dd> <p>The stream to set. The value can be any of the following.</p> <table> <tr><th>Value</th><th>Meaning</th></tr> <tr><td> <dl> <dt>0?0xFFFFFFFB</dt> </dl> </td><td> <p>The zero-based index of a stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstVideoStream"/></strong></strong></dt> <dt>0xFFFFFFFC</dt> </dl> </td><td> <p>The first video stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstAudioStream"/></strong></strong></dt> <dt>0xFFFFFFFD</dt> </dl> </td><td> <p>The first audio stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.AllStreams"/></strong></strong></dt> <dt>0xFFFFFFFE</dt> </dl> </td><td> <p>All streams.</p> </td></tr> </table> <p>?</p> </dd></param>	
    /// <param name="fSelected"><dd> <p>Specify <strong>TRUE</strong> to select streams or <strong><see cref="SharpGen.Runtime.Result.False"/></strong> to deselect streams. If a stream is deselected, it will not generate data.</p> </dd></param>	
    /// <returns><p>If this method succeeds, it returns <strong><see cref="SharpGen.Runtime.Result.Ok"/></strong>. Otherwise, it returns an <strong><see cref="SharpGen.Runtime.Result"/></strong> error code.</p></returns>	
    /// <remarks>	
    /// <p>There are two common uses for this method:</p><ul> <li>To change the default stream selection. Some media files contain multiple streams of the same type. For example, a file might include audio streams for multiple languages. You can use this method to change which of the streams is selected. To get information about each stream, call <strong><see cref="IMFSourceReader.GetPresentationAttribute"/></strong> or <strong><see cref="IMFSourceReader.GetNativeMediaType"/></strong>.</li> <li>If you will not need data from one of the streams, it is a good idea to deselect that stream. If the stream is selected, the media source might hold onto a queue of unread data, and the queue might grow indefinitely, consuming memory. </li> </ul><p>For an example of deselecting a stream, see Tutorial: Decoding Audio.</p><p>If a stream is deselected, the <strong><see cref="IMFSourceReader.ReadSample"/></strong> method returns <strong>MF_E_INVALIDREQUEST</strong> for that stream. Other <strong><see cref="IMFSourceReader"/></strong> methods are valid for deselected streams.</p><p>Stream selection does not affect how the source reader loads or unloads decoders in memory. In particular, deselecting a stream does not force the source reader to unload the decoder for that stream.</p><p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
    /// </remarks>	
    /// <msdn-id>dd374669</msdn-id>	
    /// <unmanaged>HRESULT IMFSourceReader::SetStreamSelection([In] unsigned int dwStreamIndex,[In] BOOL fSelected)</unmanaged>	
    /// <unmanaged-short>IMFSourceReader::SetStreamSelection</unmanaged-short>	
    public void SetStreamSelection(SourceReaderIndex readerIndex, bool fSelected)
    {
        SetStreamSelection((int)readerIndex, fSelected);
    }

    /// <summary>	
    /// <p><strong>Applies to: </strong>desktop apps | Metro style apps</p><p>Sets the media type for a stream.</p><p>This media type defines that format that the Source Reader produces as output. It can differ from the native format provided by the media source. See Remarks for more information.</p>	
    /// </summary>	
    /// <param name="readerIndex">No documentation.</param>	
    /// <param name="mediaTypeRef">No documentation.</param>	
    /// <returns><p>The method returns an <strong><see cref="SharpGen.Runtime.Result"/></strong>. Possible values include, but are not limited to, those in the following table.</p><table> <tr><th>Return code</th><th>Description</th></tr> <tr><td> <dl> <dt><strong><strong><see cref="SharpGen.Runtime.Result.Ok"/></strong></strong></dt> </dl> </td><td> <p>The method succeeded.</p> </td></tr> <tr><td> <dl> <dt><strong><strong>MF_E_INVALIDMEDIATYPE</strong></strong></dt> </dl> </td><td> <p>At least one decoder was found for the native stream type, but the type specified by <em>pMediaType</em> was rejected.</p> </td></tr> <tr><td> <dl> <dt><strong><strong>MF_E_INVALIDREQUEST</strong></strong></dt> </dl> </td><td> <p>One or more sample requests are still pending.</p> </td></tr> <tr><td> <dl> <dt><strong><strong>MF_E_INVALIDSTREAMNUMBER</strong></strong></dt> </dl> </td><td> <p>The <em>dwStreamIndex</em> parameter is invalid.</p> </td></tr> <tr><td> <dl> <dt><strong><strong>MF_E_TOPO_CODEC_NOT_FOUND</strong></strong></dt> </dl> </td><td> <p>Could not find a decoder for the native stream type.</p> </td></tr> </table><p>?</p></returns>	
    /// <remarks>	
    /// <p>For each stream, you can set the media type to any of the following:</p><ul> <li>One of the native types offered by the media source. To enumerate the native types, call <strong><see cref="IMFSourceReader.GetNativeMediaType"/></strong>.</li> <li>If the native media type is compressed, you can specify a corresponding uncompressed format. The Source Reader will search for a decoder that can decode from the native format to the specified uncompressed format.</li> </ul><p>The source reader does not support audio resampling. If you need to resample the audio, you can use the <strong>Audio Resampler DSP</strong>.</p><p>If you set the <see cref="SourceReaderAttributeKeys.EnableVideoProcessing"/> attribute to <strong>TRUE</strong> when you create the Source Reader, the Source Reader will convert YUV video to RGB-32. This conversion is not optimized for real-time video playback.</p><p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
    /// </remarks>	
    /// <msdn-id>dd374667</msdn-id>	
    /// <unmanaged>HRESULT IMFSourceReader::SetCurrentMediaType([In] unsigned int dwStreamIndex,[In] unsigned int* pdwReserved,[In] IMFMediaType* pMediaType)</unmanaged>	
    /// <unmanaged-short>IMFSourceReader::SetCurrentMediaType</unmanaged-short>	
    public void SetCurrentMediaType(SourceReaderIndex readerIndex, IMFMediaType mediaTypeRef)
    {
        SetCurrentMediaType((int)readerIndex, mediaTypeRef);
    }

    /// <summary>	
    /// <p><strong>Applies to: </strong>desktop apps | Metro style apps</p><p>Seeks to a new position in the media source.</p>	
    /// </summary>	
    /// <param name="position">The position from which playback will be started. 100-nanosecond units.</param>	
    /// <remarks>	
    /// <p>The <strong>SetCurrentPosition</strong> method does not guarantee exact seeking. The accuracy of the seek depends on the media content. If the media content contains a video stream, the <strong>SetCurrentPosition</strong> method typically seeks to the nearest key frame before the desired position. The distance between key frames depends on several factors, including the encoder implementation, the video content, and the particular encoding settings used to encode the content. The distance between key frame can vary within a single video file (for example, depending on scene complexity).</p><p>After seeking, the application should call <strong><see cref="IMFSourceReader.ReadSample"/></strong> and advance to the desired position. </p><p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
    /// </remarks>	
    /// <msdn-id>dd374668</msdn-id>	
    /// <unmanaged>HRESULT IMFSourceReader::SetCurrentPosition([In] const GUID&amp; guidTimeFormat,[In] const PROPVARIANT&amp; varPosition)</unmanaged>	
    /// <unmanaged-short>IMFSourceReader::SetCurrentPosition</unmanaged-short>	
    public void SetCurrentPosition(long position)
    {
        SetCurrentPosition(Guid.Empty, new Variant { Value = position });
    }

    /// <summary>	
    /// <p><strong>Applies to: </strong>desktop apps | Metro style apps</p><p>Gets the current media type for a stream.</p>	
    /// </summary>	
    /// <param name="readerIndex"><dd> <p>The stream to query. The value can be any of the following.</p> <table> <tr><th>Value</th><th>Meaning</th></tr> <tr><td> <dl> <dt>0?0xFFFFFFFB</dt> </dl> </td><td> <p>The zero-based index of a stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstVideoStream"/></strong></strong></dt> <dt>0xFFFFFFFC</dt> </dl> </td><td> <p>The first video stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstAudioStream"/></strong></strong></dt> <dt>0xFFFFFFFD</dt> </dl> </td><td> <p>The first audio stream.</p> </td></tr> </table> <p>?</p> </dd></param>	
    /// <returns><dd> <p>Receives a reference to the <strong><see cref="IMFMediaType"/></strong> interface. The caller must release the interface.</p> </dd></returns>	
    /// <remarks>	
    /// <p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
    /// </remarks>	
    /// <msdn-id>dd374660</msdn-id>	
    /// <unmanaged>HRESULT IMFSourceReader::GetCurrentMediaType([In] unsigned int dwStreamIndex,[Out] IMFMediaType** ppMediaType)</unmanaged>	
    /// <unmanaged-short>IMFSourceReader::GetCurrentMediaType</unmanaged-short>	
    public IMFMediaType GetCurrentMediaType(SourceReaderIndex readerIndex)
    {
        return GetCurrentMediaType((int)readerIndex);
    }

    /// <summary>	
    /// <p><strong>Applies to: </strong>desktop apps | Metro style apps</p><p>Reads the next sample from the media source.</p>	
    /// </summary>	
    /// <param name="dwStreamIndex"><dd> <p>The stream to pull data from. The value can be any of the following.</p> <table> <tr><th>Value</th><th>Meaning</th></tr> <tr><td> <dl> <dt>0?0xFFFFFFFB</dt> </dl> </td><td> <p>The zero-based index of a stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstVideoStream"/></strong></strong></dt> <dt>0xFFFFFFFC</dt> </dl> </td><td> <p>The first video stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstAudioStream"/></strong></strong></dt> <dt>0xFFFFFFFD</dt> </dl> </td><td> <p>The first audio stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.AnyStream"/></strong></strong></dt> <dt>0xFFFFFFFE</dt> </dl> </td><td> <p>Get the next available sample, regardless of which stream.</p> </td></tr> </table> <p>?</p> </dd></param>	
    /// <param name="dwControlFlags"><dd> <p>A bitwise <strong>OR</strong> of zero or more flags from the <strong><see cref="SourceReaderControlFlag"/></strong> enumeration.</p> </dd></param>	
    /// <param name="dwActualStreamIndexRef"><dd> <p>Receives the zero-based index of the stream.</p> </dd></param>	
    /// <param name="dwStreamFlagsRef"><dd> <p>Receives a bitwise <strong>OR</strong> of zero or more flags from the <strong><see cref="SourceReaderFlag"/></strong> enumeration.</p> </dd></param>	
    /// <param name="llTimestampRef"><dd> <p>Receives the time stamp of the sample, or the time of the stream event indicated in <em>pdwStreamFlags</em>. The time is given in 100-nanosecond units.</p> </dd></param>	
    /// <returns><dd> <p>Receives a reference to the <strong><see cref="IMFSample"/></strong> interface or the value <strong><c>null</c></strong> (see Remarks). If this parameter receives a non-<strong><c>null</c></strong> reference, the caller must release the interface.</p> </dd></returns>	
    /// <remarks>	
    /// <p>If the requested stream is not selected, the return code is <strong>MF_E_INVALIDREQUEST</strong>. See <strong><see cref="IMFSourceReader.SetStreamSelection"/></strong>.</p><p> This method can complete synchronously or asynchronously. If you provide a callback reference when you create the source reader, the method is asynchronous. Otherwise, the method is synchronous. For more information about setting the callback reference, see <see cref="SourceReaderAttributeKeys.AsyncCallback"/>.</p>Asynchronous Mode<p>In asynchronous mode:</p><ul> <li>All of the <code>[out]</code> parameters must be <strong><c>null</c></strong>. Otherwise, the method returns <strong>E_INVALIDARG</strong>.</li> <li>The method returns immediately.</li> <li>When the operation completes, the application's <strong><see cref="IMFSourceReaderCallback.OnReadSample"/></strong> method is called.</li> <li>If an error occurs, the method can fail either synchronously or asynchronously. Check the return value of <strong>ReadSample</strong>, and also check the <em>hrStatus</em> parameter of <strong><see cref="IMFSourceReaderCallback.OnReadSample"/></strong>.</li> </ul>Synchronous Mode<p>In synchronous mode:</p><ul> <li>The <em>pdwStreamFlags</em> and <em>ppSample</em> parameters cannot be <strong><c>null</c></strong>. Otherwise, the method returns <strong>E_POINTER</strong>.</li> <li>The <em>pdwActualStreamIndex</em> and <em>pllTimestamp</em> parameters can be <strong><c>null</c></strong>.</li> <li>The method blocks until the next sample is available.</li> </ul><p> In synchronous mode, if the <em>dwStreamIndex</em> parameter is <strong><see cref="SourceReaderIndex.AnyStream"/></strong>, you should pass a non-<strong><c>null</c></strong> value for <em>pdwActualStreamIndex</em>, so that you know which stream delivered the sample.</p><p>This method can return flags in the <em>pdwStreamFlags</em> parameter without returning a media sample in <em>ppSample</em>. Therefore, the <em>ppSample</em> parameter can receive a <strong><c>null</c></strong> reference even when the method succeeds. For example, when the source reader reaches the end of the stream, it returns the <strong><see cref="SourceReaderFlag.EndOfStream"/></strong> flag in <em>pdwStreamFlags</em> and sets <em>ppSample</em> to <strong><c>null</c></strong>.</p><p>If there is a gap in the stream, <em>pdwStreamFlags</em> receives the <see cref="SourceReaderFlag.StreamTick"/> flag, <em>ppSample</em> is <strong><c>null</c></strong>, and <em>pllTimestamp</em> indicates the time when the gap occurred. </p><p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
    /// </remarks>	
    /// <msdn-id>dd374665</msdn-id>	
    /// <unmanaged>HRESULT IMFSourceReader::ReadSample([In] unsigned int dwStreamIndex,[In] unsigned int dwControlFlags,[Out, Optional] unsigned int* pdwActualStreamIndex,[Out, Optional] unsigned int* pdwStreamFlags,[Out, Optional] longlong* pllTimestamp,[Out, Optional] IMFSample** ppSample)</unmanaged>	
    /// <unmanaged-short>IMFSourceReader::ReadSample</unmanaged-short>	
    public IMFSample ReadSample(SourceReaderIndex dwStreamIndex, SourceReaderControlFlag dwControlFlags, out int dwActualStreamIndexRef, out SourceReaderFlag dwStreamFlagsRef, out long llTimestampRef)
    {
        return ReadSample((int)dwStreamIndex, dwControlFlags, out dwActualStreamIndexRef, out dwStreamFlagsRef, out llTimestampRef);
    }

    /// <summary>	
    /// <p><strong>Applies to: </strong>desktop apps | Metro style apps</p><p>Flushes one or more streams.</p>	
    /// </summary>	
    /// <param name="dwStreamIndex"><dd> <p>The stream to flush. The value can be any of the following.</p> <table> <tr><th>Value</th><th>Meaning</th></tr> <tr><td> <dl> <dt>0?0xFFFFFFFB</dt> </dl> </td><td> <p>The zero-based index of a stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstVideoStream"/></strong></strong></dt> <dt>0xFFFFFFFC</dt> </dl> </td><td> <p>The first video stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstAudioStream"/></strong></strong></dt> <dt>0xFFFFFFFD</dt> </dl> </td><td> <p>The first audio stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.AllStreams"/></strong></strong></dt> <dt>0xFFFFFFFE</dt> </dl> </td><td> <p>All streams.</p> </td></tr> </table> <p>?</p> </dd></param>	
    /// <returns><p>If this method succeeds, it returns <strong><see cref="SharpGen.Runtime.Result.Ok"/></strong>. Otherwise, it returns an <strong><see cref="SharpGen.Runtime.Result"/></strong> error code.</p></returns>	
    /// <remarks>	
    /// <p>The <strong>Flush</strong> method discards all queued samples and cancels all pending sample requests.</p><p>This method can complete either synchronously or asynchronously. If you provide a callback reference when you create the source reader, the method is asynchronous. Otherwise, the method is synchronous. For more information about the setting the callback reference, see <see cref="SourceReaderAttributeKeys.AsyncCallback"/>.</p><p>In synchronous mode, the method blocks until the operation is complete.</p><p>In asynchronous mode, the application's <strong><see cref="IMFSourceReaderCallback.OnFlush"/></strong> method is called when the flush operation completes. While a flush operation is pending, the <strong><see cref="IMFSourceReader.ReadSample"/></strong> method returns <strong>MF_E_NOTACCEPTING</strong>.</p><p><strong>Note</strong>??In Windows?7, there was a bug in the implementation of this method, which causes <strong>OnFlush</strong> to be called before the flush operation completes. A hotfix is available that fixes this bug. For more information, see http://support.microsoft.com/kb/979567.</p><p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
    /// </remarks>	
    /// <msdn-id>dd374659</msdn-id>	
    /// <unmanaged>HRESULT IMFSourceReader::Flush([In] unsigned int dwStreamIndex)</unmanaged>	
    /// <unmanaged-short>IMFSourceReader::Flush</unmanaged-short>	
    public void Flush(SourceReaderIndex dwStreamIndex)
    {
        Flush((int)dwStreamIndex);
    }

    /// <summary>	
    /// <p><strong>Applies to: </strong>desktop apps | Metro style apps</p><p>Queries the underlying media source or decoder for an interface.</p>	
    /// </summary>	
    /// <param name="streamIndex"><dd> <p>The stream or object to query. If the value is <strong><see cref="SourceReaderIndex.MediaSource"/></strong>, the method queries the media source. Otherwise, it queries the decoder that is associated with the specified stream. The following values are possible.</p> <table> <tr><th>Value</th><th>Meaning</th></tr> <tr><td> <dl> <dt>0?0xFFFFFFFB</dt> </dl> </td><td> <p>The zero-based index of a stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstVideoStream"/></strong></strong></dt> <dt>0xFFFFFFFC</dt> </dl> </td><td> <p>The first video stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstAudioStream"/></strong></strong></dt> <dt>0xFFFFFFFD</dt> </dl> </td><td> <p>The first audio stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.MediaSource"/></strong></strong></dt> <dt>0xFFFFFFFF</dt> </dl> </td><td> <p>The media source.</p> </td></tr> </table> <p>?</p> </dd></param>	
    /// <param name="guidService"><dd> <p>A service identifier <see cref="Guid"/>.  If the value is <strong>GUID_NULL</strong>, the method calls <strong>QueryInterface</strong> to get the requested interface. Otherwise, the method calls the <strong><see cref="IMFGetService.GetService"/></strong> method. For a list of service identifiers, see Service Interfaces.</p> </dd></param>	
    /// <param name="riid"><dd> <p>The interface identifier (IID) of the interface being requested. </p> </dd></param>	
    /// <returns><dd> <p>Receives a reference to the requested interface. The caller must release the interface.</p> </dd></returns>	
    /// <remarks>	
    /// <p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
    /// </remarks>	
    /// <msdn-id>dd374663</msdn-id>	
    /// <unmanaged>HRESULT IMFSourceReader::GetServiceForStream([In] unsigned int dwStreamIndex,[In] const GUID&amp; guidService,[In] const GUID&amp; riid,[Out] void** ppvObject)</unmanaged>	
    /// <unmanaged-short>IMFSourceReader::GetServiceForStream</unmanaged-short>	
    public nint GetServiceForStream(SourceReaderIndex streamIndex, Guid guidService, Guid riid)
    {
        return GetServiceForStream((int)streamIndex, guidService, riid);
    }

    /// <summary>	
    /// <p><strong>Applies to: </strong>desktop apps | Metro style apps</p><p>Gets an attribute from the underlying media source.</p>	
    /// </summary>	
    /// <param name="streamIndex"><dd> <p>The stream or object to query. The value can be any of the following.</p> <table> <tr><th>Value</th><th>Meaning</th></tr> <tr><td> <dl> <dt>0?0xFFFFFFFB</dt> </dl> </td><td> <p>The zero-based index of a stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstVideoStream"/></strong></strong></dt> <dt>0xFFFFFFFC</dt> </dl> </td><td> <p>The first video stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstAudioStream"/></strong></strong></dt> <dt>0xFFFFFFFD</dt> </dl> </td><td> <p>The first audio stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.MediaSource"/></strong></strong></dt> <dt>0xFFFFFFFF</dt> </dl> </td><td> <p>The media source.</p> </td></tr> </table> <p>?</p> </dd></param>	
    /// <param name="guidAttribute"><dd> <p>A <see cref="Guid"/> that identifies the attribute to retrieve. If the <em>dwStreamIndex</em> parameter equals  <strong><see cref="SourceReaderIndex.MediaSource"/></strong>, <em>guidAttribute</em> can specify one of the following:</p> <ul> <li>A presentation descriptor attribute. For a list of values, see Presentation Descriptor Attributes.</li> <li> <see cref="SourceReaderAttributeKeys.MediaSourceCharacteristics"/>. Use this value to get characteristics flags from the media source.</li> </ul> <p>Otherwise, if the <em>dwStreamIndex</em> parameter specifies a stream, <em>guidAttribute</em> specifies a stream descriptor attribute. For a list of values, see Stream Descriptor Attributes.</p> </dd></param>	
    /// <returns>a <strong><see cref="Variant"/></strong> that receives the value of the attribute.</returns>	
    /// <remarks>	
    /// <p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
    /// </remarks>	
    /// <msdn-id>dd374662</msdn-id>	
    /// <unmanaged>HRESULT IMFSourceReader::GetPresentationAttribute([In] unsigned int dwStreamIndex,[In] const GUID&amp; guidAttribute,[Out] PROPVARIANT* pvarAttribute)</unmanaged>	
    /// <unmanaged-short>IMFSourceReader::GetPresentationAttribute</unmanaged-short>	
    public T GetPresentationAttribute<T>(SourceReaderIndex streamIndex, MediaAttributeKey<T> guidAttribute)
    {
        Variant variant = GetPresentationAttribute((int)streamIndex, guidAttribute.Guid);

        return (T)Convert.ChangeType(variant.Value, typeof(T));
    }

    /// <summary>	
    /// <p><strong>Applies to: </strong>desktop apps | Metro style apps</p><p>Gets an attribute from the underlying media source.</p>	
    /// </summary>	
    /// <param name="dwStreamIndex"><dd> <p>The stream or object to query. The value can be any of the following.</p> <table> <tr><th>Value</th><th>Meaning</th></tr> <tr><td> <dl> <dt>0?0xFFFFFFFB</dt> </dl> </td><td> <p>The zero-based index of a stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstVideoStream"/></strong></strong></dt> <dt>0xFFFFFFFC</dt> </dl> </td><td> <p>The first video stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.FirstAudioStream"/></strong></strong></dt> <dt>0xFFFFFFFD</dt> </dl> </td><td> <p>The first audio stream.</p> </td></tr> <tr><td><dl> <dt><strong><strong><see cref="SourceReaderIndex.MediaSource"/></strong></strong></dt> <dt>0xFFFFFFFF</dt> </dl> </td><td> <p>The media source.</p> </td></tr> </table> <p>?</p> </dd></param>	
    /// <param name="guidAttribute"><dd> <p>A <see cref="Guid"/> that identifies the attribute to retrieve. If the <em>dwStreamIndex</em> parameter equals  <strong><see cref="SourceReaderIndex.MediaSource"/></strong>, <em>guidAttribute</em> can specify one of the following:</p> <ul> <li>A presentation descriptor attribute. For a list of values, see Presentation Descriptor Attributes.</li> <li> <see cref="SourceReaderAttributeKeys.MediaSourceCharacteristics"/>. Use this value to get characteristics flags from the media source.</li> </ul> <p>Otherwise, if the <em>dwStreamIndex</em> parameter specifies a stream, <em>guidAttribute</em> specifies a stream descriptor attribute. For a list of values, see Stream Descriptor Attributes.</p> </dd></param>	
    /// <returns>a <strong><see cref="Variant"/></strong> that receives the value of the attribute.</returns>	
    /// <remarks>	
    /// <p>This interface is available on Windows?Vista if Platform Update Supplement for Windows?Vista is installed.</p>	
    /// </remarks>	
    /// <msdn-id>dd374662</msdn-id>	
    /// <unmanaged>HRESULT IMFSourceReader::GetPresentationAttribute([In] unsigned int dwStreamIndex,[In] const GUID&amp; guidAttribute,[Out] PROPVARIANT* pvarAttribute)</unmanaged>	
    /// <unmanaged-short>IMFSourceReader::GetPresentationAttribute</unmanaged-short>	
    public Variant GetPresentationAttribute(SourceReaderIndex dwStreamIndex, Guid guidAttribute)
    {
        return GetPresentationAttribute((int)dwStreamIndex, guidAttribute);
    }

    protected override void DisposeCore(nint nativePointer, bool disposing)
    {
        base.DisposeCore(nativePointer, disposing);

        if (_byteStream != null)
        {
            _byteStream.Dispose();
            _byteStream = null;
        }
    }
}
