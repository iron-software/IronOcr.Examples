# Utilizing Iron Tesseract with IronOCR

> Full guide: [Utilizing Iron Tesseract with IronOCR](https://ironsoftware.com/how-to/iron-tesseract/)

IronOCR offers a straightforward API that leverages the enhanced capabilities of Tesseract 5, also known as Iron Tesseract. By integrating IronOCR alongside IronTesseract, users can efficiently transform text from images and scanned documents into editable text and searchable PDF formats.

## Quick Setup: Configuring IronTesseract with C#

Kickstart your IronTesseract implementation quickly with this guide. Below is a simple demonstration outlining how to activate the engine, adjust the necessary settings, and execute OCR with minimal effort - just a single image and a single function call, no extra setup required.

```cs
var ocrResult = new IronOcr.IronTesseract 
{
    Language = IronOcr.OcrLanguage.English,
    Configuration = new IronOcr.TesseractConfiguration
    {
        ReadBarCodes = false,
        RenderSearchablePdf = true,
        WhiteListCharacters = "ABCabc123"
    }
}.Read(new IronOcr.OcrInput("image.png"));
```

## Initializing an IronTesseract Object

To start using IronTesseract in your applications, begin by creating an instance of the `Tesseract` object as demonstrated below:

```csharp
using IronOcr;

IronTesseract ocrInstance = new IronTesseract();
```

```csharp
using IronOcr;

// Instantiate the IronTesseract class
IronTesseract tesseractOcr = new IronTesseract();
```

You can tailor the functionality of IronTesseract to suit your specific needs by selecting from various languages, enabling barcode recognition, and managing character recognition through whitelisting or blacklisting specific characters.

```csharp
IronTesseract tesseractInstance = new IronTesseract
{
    Configuration = new TesseractConfiguration
    {
        ReadBarCodes = false, // Disable barcode reading
        RenderHocr = true, // Enable output in hOCR format
        TesseractVariables = null, // No custom variables
        WhiteListCharacters = null, // No whitelist specified
        BlackListCharacters = "`ë|^", // Characters to exclude during OCR
    },
    MultiThreaded = false, // Single-threaded operation
    Language = OcrLanguage.English, // Set OCR language to English
    EnableTesseractConsoleMessages = true, // Enable console messages, default is false
};
```

After configuring, you are all set to utilize the capabilities of Tesseract for recognizing text within `OcrInput` objects:

```csharp
// Instantiate the IronTesseract class
IronTesseract ocrInstance = new IronTesseract();

// Create an OcrInput object and load an image for OCR processing
using OcrInput imageInput = new OcrInput();
imageInput.LoadImage("attachment.png");

// Perform OCR on the loaded image and store the results
OcrResult ocrScanResult = ocrInstance.Read(imageInput);
string extractedText = ocrScanResult.Text;
```

## Detailed Tesseract Settings Customization

You can take advantage of the complete management of Tesseract's settings using IronOcr's [`IronOcr.TesseractConfiguration` Class](https://ironsoftware.com/csharp/ocr/object-reference/api/IronOcr.TesseractConfiguration.html).

### Example: Configuring Tesseract with IronOCR

Below is a practical example illustrating how to configure Tesseract using the IronOCR API. This code snippet covers setting the language, adjusting the page segmentation mode, and customizing various Tesseract engine parameters:

```csharp
using IronOcr;
using System;

// Creating an instance of IronTesseract
IronTesseract Ocr = new IronTesseract();

// Setting OCR language
Ocr.Language = OcrLanguage.English;

// Configuration adjustments
Ocr.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.AutoOsd;

// Modifying Tesseract engine variables
Ocr.Configuration.TesseractVariables["tessedit_parallelize"] = false;

// Preparing the OCR input
using var input = new OcrInput();
input.LoadImage("https://www.ironsoftware.com/csharp/ocr/path/file.png");

// Executing text extraction
OcrResult Result = Ocr.Read(input);
Console.WriteLine(Result.Text);
```
This code initializes an `IronTesseract` object, configures it for English OCR, and sets up the page segmentation mode. It also applies a specific Tesseract variable for parallel processing. After loading an image, it employs the OCR engine to read the image and prints the extracted text.

```csharp
using IronOcr;
using System;

// Initialize IronTesseract
IronTesseract ocrEngine = new IronTesseract();

// Set the OCR language to English
ocrEngine.Language = OcrLanguage.English;
// Set the page segmentation mode
ocrEngine.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.AutoOsd;

// Disable parallel processing for Tesseract
ocrEngine.Configuration.TesseractVariables["tessedit_parallelize"] = false;

// Create an input object and load an image
using var input = new OcrInput();
input.LoadImage("https://ironsoftware.com/path/file.png");

// Execute OCR and obtain results
OcrResult ocrResult = ocrEngine.Read(input);
// Output the extracted text to the console
Console.WriteLine(ocrResult.Text);
```

## Comprehensive Tesseract Configuration Options

For configuring Tesseract variables within IronTesseract, you can set them via the command:

```csharp
IronTesseract.Configuration.TesseractVariables["key"] = "value";
```

<table class="table table__configuration-variables">
    <tr>
        <th scope="col">Tesseract Config Variable</th>
        <th scope="col">Default</th>
        <th scope="col">Meaning</th>
    </tr>
    <tr><td>classify_num_cp_levels</td><td>3</td><td>Number of Class Pruner Levels</td></tr>
    <tr><td>textord_debug_tabfind</td><td>0</td><td>Debug tab finding </td></tr>
    <tr><td>textord_debug_bugs</td><td>0</td><td>Turn on output related to bugs in tab finding </td></tr>
    <tr><td>textord_testregion_left</td><td>-1</td><td>Left edge of debug reporting rectangle </td></tr>
    <tr><td>textord_testregion_top</td><td>-1</td><td>Top edge of debug reporting rectangle </td></tr>
    <tr><td>textord_testregion_right</td><td>2147483647</td><td>Right edge of debug rectangle </td></tr>
    <tr><td>textord_testregion_bottom</td><td>2147483647</td><td>Bottom edge of debug rectangle </td></tr>
    <tr><td>textord_tabfind_show_partitions</td><td>0</td><td>Show partition bounds, waiting if >1 </td></tr>
    <tr><td>devanagari_split_debuglevel</td><td>0</td><td>Debug level for split shiro-rekha process. </td></tr>
    <tr><td>edges_max_children_per_outline</td><td>10</td><td>Max number of children inside a character outline </td></tr>
    <tr><td>edges_max_children_layers</td><td>5</td><td>Max layers of nested children inside a character outline </td></tr>
    <tr><td>edges_children_per_grandchild</td><td>10</td><td>Importance ratio for chucking outlines </td></tr>
    <tr><td>edges_children_count_limit</td><td>45</td><td>Max holes allowed in blob </td></tr>
    <tr><td>edges_min_nonhole</td><td>12</td><td>Min pixels for potential char in box </td></tr>
    <tr><td>edges_patharea_ratio</td><td>40</td><td>Max lensq/area for acceptable child outline </td></tr>
    <tr><td>textord_fp_chop_error</td><td>2</td><td>Max allowed bending of chop cells </td></tr>
    <tr><td>textord_tabfind_show_images</td><td>0</td><td>Show image blobs </td></tr>
    <tr><td>textord_skewsmooth_offset</td><td>4</td><td>For smooth factor </td></tr>
    <tr><td>textord_skewsmooth_offset2</td><td>1</td><td>For smooth factor </td></tr>
    <tr><td>textord_test_x</td><td>-2147483647</td><td>coord of test pt </td></tr>
    <tr><td>textord_test_y</td><td>-2147483647</td><td>coord of test pt </td></tr>
    <tr><td>textord_min_blobs_in_row</td><td>4</td><td>Min blobs before gradient counted </td></tr>
    <tr><td>textord_spline_minblobs</td><td>8</td><td>Min blobs in each spline segment </td></tr>
    <tr><td>textord_spline_medianwin</td><td>6</td><td>Size of window for spline segmentation </td></tr>
    <tr><td>textord_max_blob_overlaps</td><td>4</td><td>Max number of blobs a big blob can overlap </td></tr>
    <tr><td>textord_min_xheight</td><td>10</td><td>Min credible pixel xheight </td></tr>
    <tr><td>textord_lms_line_trials</td><td>12</td><td>Number of linew fits to do </td></tr>
    <tr><td>oldbl_holed_losscount</td><td>10</td><td>Max lost before fallback line used </td></tr>
    <tr><td>pitsync_linear_version</td><td>6</td><td>Use new fast algorithm </td></tr>
    <tr><td>pitsync_fake_depth</td><td>1</td><td>Max advance fake generation </td></tr>
    <tr><td>textord_tabfind_show_strokewidths</td><td>0</td><td>Show stroke widths </td></tr>
    <tr><td>textord_dotmatrix_gap</td><td>3</td><td>Max pixel gap for broken pixed pitch </td></tr>
    <tr><td>textord_debug_block</td><td>0</td><td>Block to do debug on </td></tr>
    <tr><td>textord_pitch_range</td><td>2</td><td>Max range test on pitch </td></tr>
    <tr><td>textord_words_veto_power</td><td>5</td><td>Rows required to outvote a veto </td></tr>
    <tr><td>equationdetect_save_bi_image</td><td>0</td><td>Save input bi image </td></tr>
    <tr><td>equationdetect_save_spt_image</td><td>0</td><td>Save special character image </td></tr>
    <tr><td>equationdetect_save_seed_image</td><td>0</td><td>Save the seed image </td></tr>
    <tr><td>equationdetect_save_merged_image</td><td>0</td><td>Save the merged image </td></tr>
    <tr><td>poly_debug</td><td>0</td><td>Debug old poly </td></tr>
    <tr><td>poly_wide_objects_better</td><td>1</td><td>More accurate approx on wide things </td></tr>
    <tr><td>wordrec_display_splits</td><td>0</td><td>Display splits </td></tr>
    <tr><td>textord_debug_printable</td><td>0</td><td>Make debug windows printable </td></tr>
    <tr><td>textord_space_size_is_variable</td><td>0</td><td>If true, word delimiter spaces are assumed to have variable width, even though characters have fixed pitch. </td></tr>
    <tr><td>textord_tabfind_show_initial_partitions</td><td>0</td><td>Show partition bounds </td></tr>
    <tr><td>textord_tabfind_show_reject_blobs</td><td>0</td><td>Show blobs rejected as noise </td></tr>
    <tr><td>textord_tabfind_show_columns</td><td>0</td><td>Show column bounds </td></tr>
    <tr><td>textord_tabfind_show_blocks</td><td>0</td><td>Show final block bounds </td></tr>
    <tr><td>textord_tabfind_find_tables</td><td>1</td><td>run table detection </td></tr>
    <tr><td>devanagari_split_debugimage</td><td>0</td><td>Whether to create a debug image for split shiro-rekha process. </td></tr>
    <tr><td>textord_show_fixed_cuts</td><td>0</td><td>Draw fixed pitch cell boundaries </td></tr>
    <tr><td>edges_use_new_outline_complexity</td><td>0</td><td>Use the new outline complexity module </td></tr>
    <tr><td>edges_debug</td><td>0</td><td>turn on debugging for this module </td></tr>
    <tr><td>edges_children_fix</td><td>0</td><td>Remove boxy parents of char-like children </td></tr>
    <tr><td>gapmap_debug</td><td>0</td><td>Say which blocks have tables </td></tr>
    <tr><td>gapmap_use_ends</td><td>0</td><td>Use large space at start and end of rows </td></tr>
    <tr><td>gapmap_no_isolated_quanta</td><td>0</td><td>Ensure gaps not less than 2quanta wide </td></tr>
    <tr><td>textord_heavy_nr</td><td>0</td><td>Vigorously remove noise </td></tr>
    <tr><td>textord_show_initial_rows</td><td>0</td><td>Display row accumulation </td></tr>
    <tr><td>textord_show_parallel_rows</td><td>0</td><td>Display page correlated rows </td></tr>
    <tr><td>textord_show_expanded_rows</td><td>0</td><td>Display rows after expanding </td></tr>
    <tr><td>textord_show_final_rows</td><td>0</td><td>Display rows after final fitting </td></tr>
    <tr><td>textord_show_final_blobs</td><td>0</td><td>Display blob bounds after pre-ass </td></tr>
    <tr><td>textord_test_landscape</td><td>0</td><td>Tests refer to land/port </td></tr>
    <tr><td>textord_parallel_baselines</td><td>1</td><td>Force parallel baselines </td></tr>
    <tr><td>textord_straight_baselines</td><td>0</td><td>Force straight baselines </td></tr>
    <tr><td>textord_old_baselines</td><td>1</td><td>Use old baseline algorithm </td></tr>
    <tr><td>textord_old_xheight</td><td>0</td><td>Use old xheight algorithm </td></tr>
    <tr><td>textord_fix_xheight_bug</td><td>1</td><td>Use spline baseline </td></tr>
    <tr><td>textord_fix_makerow_bug</td><td>1</td><td>Prevent multiple baselines </td></tr>
    <tr><td>textord_debug_xheights</td><td>0</td><td>Test xheight algorithms </td></tr>
    <tr><td>textord_biased_skewcalc</td><td>1</td><td>Bias skew estimates with line length </td></tr>
    <tr><td>textord_interpolating_skew</td><td>1</td><td>Interpolate across gaps </td></tr>
    <tr><td>textord_new_initial_xheight</td><td>1</td><td>Use test xheight mechanism </td></tr>
    <tr><td>textord_debug_blob</td><td>0</td><td>Print test blob information </td></tr>
    <tr><td>textord_really_old_xheight</td><td>0</td><td>Use original wiseowl xheight </td></tr>
    <tr><td>textord_oldbl_debug</td><td>0</td><td>Debug old baseline generation </td></tr>
    <tr><td>textord_debug_baselines</td><td>0</td><td>Debug baseline generation </td></tr>
    <tr><td>textord_oldbl_paradef</td><td>1</td><td>Use para default mechanism </td></tr>
    <tr><td>textord_oldbl_split_splines</td><td>1</td><td>Split stepped splines </td></tr>
    <tr><td>textord_oldbl_merge_parts</td><td>1</td><td>Merge suspect partitions </td></tr>
    <tr><td>oldbl_corrfix</td><td>1</td><td>Improve correlation of heights </td></tr>
    <tr><td>oldbl_xhfix</td><td>0</td><td>Fix bug in modes threshold for xheights </td></tr>
    <tr><td>textord_ocropus_mode</td><td>0</td><td>Make baselines for ocropus </td></tr>
    <tr><td>textord_tabfind_only_strokewidths</td><td>0</td><td>Only run stroke widths </td></tr>
    <tr><td>textord_tabfind_show_initialtabs</td><td>0</td><td>Show tab candidates </td></tr>
    <tr><td>textord_tabfind_show_finaltabs</td><td>0</td><td>Show tab vectors </td></tr>
    <tr><td>textord_show_tables</td><td>0</td><td>Show table regions </td></tr>
    <tr><td>textord_tablefind_show_mark</td><td>0</td><td>Debug table marking steps in detail </td></tr>
    <tr><td>textord_tablefind_show_stats</td><td>0</td><td>Show page stats used in table finding </td></tr>
    <tr><td>textord_tablefind_recognize_tables</td><td>0</td><td>Enables the table recognizer for table layout and filtering. </td></tr>
    <tr><td>textord_all_prop</td><td>0</td><td>All doc is proportial text </td></tr>
    <tr><td>textord_debug_pitch_test</td><td>0</td><td>Debug on fixed pitch test </td></tr>
    <tr><td>textord_disable_pitch_test</td><td>0</td><td>Turn off dp fixed pitch algorithm </td></tr>
    <tr><td>textord_fast_pitch_test</td><td>0</td><td>Do even faster pitch algorithm </td></tr>
    <tr><td>textord_debug_pitch_metric</td><td>0</td><td>Write full metric stuff </td></tr>
    <tr><td>textord_show_row_cuts</td><td>0</td><td>Draw row-level cuts </td></tr>
    <tr><td>textord_show_page_cuts</td><td>0</td><td>Draw page-level cuts </td></tr>
    <tr><td>textord_pitch_cheat</td><td>0</td><td>Use correct answer for fixed/prop </td></tr>
    <tr><td>textord_blockndoc_fixed</td><td>0</td><td>Attempt whole doc/block fixed pitch </td></tr>
    <tr><td>textord_show_initial_words</td><td>0</td><td>Display separate words </td></tr>
    <tr><td>textord_show_new_words</td><td>0</td><td>Display separate words </td></tr>
    <tr><td>textord_show_fixed_words</td><td>0</td><td>Display forced fixed pitch words </td></tr>
    <tr><td>textord_blocksall_fixed</td><td>0</td><td>Moan about prop blocks </td></tr>
    <tr><td>textord_blocksall_prop</td><td>0</td><td>Moan about fixed pitch blocks </td></tr>
    <tr><td>textord_blocksall_testing</td><td>0</td><td>Dump stats when moaning </td></tr>
    <tr><td>textord_test_mode</td><td>0</td><td>Do current test </td></tr>
    <tr><td>textord_pitch_scalebigwords</td><td>0</td><td>Scale scores on big words </td></tr>
    <tr><td>textord_restore_underlines</td><td>1</td><td>Chop underlines & put back </td></tr>
    <tr><td>textord_fp_chopping</td><td>1</td><td>Do fixed pitch chopping </td></tr>
    <tr><td>textord_force_make_prop_words</td><td>0</td><td>Force proportional word segmentation on all rows </td></tr>
    <tr><td>textord_chopper_test</td><td>0</td><td>Chopper is being tested. </td></tr>
    <tr><td>wordrec_display_all_blobs</td><td>0</td><td>Display Blobs </td></tr>
    <tr><td>wordrec_blob_pause</td><td>0</td><td>Blob pause </td></tr>
    <tr><td>stream_filelist</td><td>0</td><td>Stream a filelist from stdin </td></tr>
    <tr><td>debug_file</td><td></td><td> File to send tprintf output to </td></tr>
    <tr><td>classify_font_name</td><td>UnknownFont</td><td>Default font name to be used in training </td></tr>
    <tr><td>document_title</td><td> </td><td>Title of output document (used for hOCR and PDF output) </td></tr>
    <tr><td>dotproduct</td><td>auto</td><td>Function used for calculation of dot product </td></tr>
    <tr><td>classify_cp_angle_pad_loose</td><td>45</td><td>Class Pruner Angle Pad Loose </td></tr>
    <tr><td>classify_cp_angle_pad_medium</td><td>20</td><td>Class Pruner Angle Pad Medium </td></tr>
    <tr><td>classify_cp_angle_pad_tight</td><td>10</td><td>CLass Pruner Angle Pad Tight </td></tr>
    <tr><td>classify_cp_end_pad_loose</td><td>0.5</td><td>Class Pruner End Pad Loose </td></tr>
    <tr><td>classify_cp_end_pad_medium</td><td>0.5</td><td>Class Pruner End Pad Medium </td></tr>
    <tr><td>classify_cp_end_pad_tight</td><td>0.5</td><td>Class Pruner End Pad Tight </td></tr>
    <tr><td>classify_cp_side_pad_loose</td><td>2.5</td><td>Class Pruner Side Pad Loose </td></tr>
    <tr><td>classify_cp_side_pad_medium</td><td>1.2</td><td>Class Pruner Side Pad Medium </td></tr>
    <tr><td>classify_cp_side_pad_tight</td><td>0.6</td><td>Class Pruner Side Pad Tight </td></tr>
    <tr><td>classify_pp_angle_pad</td><td>45</td><td>Proto Pruner Angle Pad </td></tr>
    <tr><td>classify_pp_end_pad</td><td>0.5</td><td>Proto Prune End Pad </td></tr>
    <tr><td>classify_pp_side_pad</td><td>2.5</td><td>Proto Pruner Side Pad </td></tr>
    <tr><td>classify_min_slope</td><td>0.414214</td><td>Slope below which lines are called horizontal </td></tr>
    <tr><td>classify_max_slope</td><td>2.41421</td><td>Slope above which lines are called vertical </td></tr>
    <tr><td>classify_norm_adj_midpoint</td><td>32</td><td>Norm adjust midpoint ... </td></tr>
    <tr><td>classify_norm_adj_curl</td><td>2</td><td>Norm adjust curl ... </td></tr>
    <tr><td>classify_pico_feature_length</td><td>0.05</td><td>Pico Feature Length </td></tr>
    <tr><td>textord_underline_threshold</td><td>0.5</td><td>Fraction of width occupied </td></tr>
    <tr><td>edges_childarea</td><td>0.5</td><td>Min area fraction of child outline </td></tr>
    <tr><td>edges_boxarea</td><td>0.875</td><td>Min area fraction of grandchild for box </td></tr>
    <tr><td>textord_fp_chop_snap</td><td>0.5</td><td>Max distance of chop pt from vertex </td></tr>
    <tr><td>gapmap_big_gaps</td><td>1.75</td><td>xht multiplier </td></tr>
    <tr><td>textord_spline_shift_fraction</td><td>0.02</td><td>Fraction of line spacing for quad </td></tr>
    <tr><td>textord_spline_outlier_fraction</td><td>0.1</td><td>Fraction of line spacing for outlier </td></tr>
    <tr><td>textord_skew_ile</td><td>0.5</td><td>Ile of gradients for page skew </td></tr>
    <tr><td>textord_skew_lag</td><td>0.02</td><td>Lag for skew on row accumulation </td></tr>
    <tr><td>textord_linespace_iqrlimit</td><td>0.2</td><td>Max iqr/median for linespace </td></tr>
    <tr><td>textord_width_limit</td><td>8</td><td>Max width of blobs to make rows </td></tr>
    <tr><td>textord_chop_width</td><td>1.5</td><td>Max width before chopping </td></tr>
    <tr><td>textord_expansion_factor</td><td>1</td><td>Factor to expand rows by in expand_rows </td></tr>
    <tr><td>textord_overlap_x</td><td>0.375</td><td>Fraction of linespace for good overlap </td></tr>
    <tr><td>textord_minxh</td><td>0.25</td><td>fraction of linesize for min xheight </td></tr>
    <tr><td>textord_min_linesize</td><td>1.25</td><td>* blob height for initial linesize </td></tr>
    <tr><td>textord_excess_blobsize</td><td>1.3</td><td>New row made if blob makes row this big </td></tr>
    <tr><td>textord_occupancy_threshold</td><td>0.4</td><td>Fraction of neighbourhood </td></tr>
    <tr><td>textord_underline_width</td><td>2</td><td>Multiple of line_size for underline </td></tr>
    <tr><td>textord_min_blob_height_fraction</td><td>0.75</td><td>Min blob height/top to include blob top into xheight stats </td></tr>
    <tr><td>textord_xheight_mode_fraction</td><td>0.4</td><td>Min pile height to make xheight </td></tr>
    <tr><td>textord_ascheight_mode_fraction</td><td>0.08</td><td>Min pile height to make ascheight </td></tr>
    <tr><td>textord_descheight_mode_fraction</td><td>0.08</td><td>Min pile height to make descheight </td></tr>
    <tr><td>textord_ascx_ratio_min</td><td>1.25</td><td>Min cap/xheight </td></tr>
    <tr><td>textord_ascx_ratio_max</td><td>1.8</td><td>Max cap/xheight </td></tr>
    <tr><td>textord_descx_ratio_min</td><td>0.25</td><td>Min desc/xheight </td></tr>
    <tr><td>textord_descx_ratio_max</td><td>0.6</td><td>Max desc/xheight </td></tr>
    <tr><td>textord_xheight_error_margin</td><td>0.1</td><td>Accepted variation </td></tr>
    <tr><td>oldbl_xhfract</td><td>0.4</td><td>Fraction of est allowed in calc </td></tr>
    <tr><td>oldbl_dot_error_size</td><td>1.26</td><td>Max aspect ratio of a dot </td></tr>
    <tr><td>textord_oldbl_jumplimit</td><td>0.15</td><td>X fraction for new partition </td></tr>
    <tr><td>pitsync_joined_edge</td><td>0.75</td><td>Dist inside big blob for chopping </td></tr>
    <tr><td>pitsync_offset_freecut_fraction</td><td>0.25</td><td>Fraction of cut for free cuts </td></tr>
    <tr><td>textord_tabvector_vertical_gap_fraction</td><td>0.5</td><td>max fraction of mean blob width allowed for vertical gaps in vertical text </td></tr>
    <tr><td>textord_tabvector_vertical_box_ratio</td><td>0.5</td><td>Fraction of box matches required to declare a line vertical </td></tr>
    <tr><td>textord_projection_scale</td><td>0.2</td><td>Ding rate for mid-cuts </td></tr>
    <tr><td>textord_balance_factor</td><td>1</td><td>Ding rate for unbalanced char cells </td></tr>
    <tr><td>textord_wordstats_smooth_factor</td><td>0.05</td><td>Smoothing gap stats </td></tr>
    <tr><td>textord_width_smooth_factor</td><td>0.1</td><td>Smoothing width stats </td></tr>
    <tr><td>textord_words_width_ile</td><td>0.4</td><td>Ile of blob widths for space est </td></tr>
    <tr><td>textord_words_maxspace</td><td>4</td><td>Multiple of xheight </td></tr>
    <tr><td>textord_words_default_maxspace</td><td>3.5</td><td>Max believable third space </td></tr>
    <tr><td>textord_words_default_minspace</td><td>0.6</td><td>Fraction of xheight </td></tr>
    <tr><td>textord_words_min_minspace</td><td>0.3</td><td>Fraction of xheight </td></tr>
    <tr><td>textord_words_default_nonspace</td><td>0.2</td><td>Fraction of xheight </td></tr>
    <tr><td>textord_words_initial_lower</td><td>0.25</td><td>Max initial cluster size </td></tr>
    <tr><td>textord_words_initial_upper</td><td>0.15</td><td>Min initial cluster spacing </td></tr>
    <tr><td>textord_words_minlarge</td><td>0.75</td><td>Fraction of valid gaps needed </td></tr>
    <tr><td>textord_words_pitchsd_threshold</td><td>0.04</td><td>Pitch sync threshold </td></tr>
    <tr><td>textord_words_def_fixed</td><td>0.016</td><td>Threshold for definite fixed </td></tr>
    <tr><td>textord_words_def_prop</td><td>0.09</td><td>Threshold for definite prop </td></tr>
    <tr><td>textord_pitch_rowsimilarity</td><td>0.08</td><td>Fraction of xheight for sameness </td></tr>
    <tr><td>words_initial_lower</td><td>0.5</td><td>Max initial cluster size </td></tr>
    <tr><td>words_initial_upper</td><td>0.15</td><td>Min initial cluster spacing </td></tr>
    <tr><td>words_default_prop_nonspace</td><td>0.25</td><td>Fraction of xheight </td></tr>
    <tr><td>words_default_fixed_space</td><td>0.75</td><td>Fraction of xheight </td></tr>
    <tr><td>words_default_fixed_limit</td><td>0.6</td><td>Allowed size variance </td></tr>
    <tr><td>textord_words_definite_spread</td><td>0.3</td><td>Non-fuzzy spacing region </td></tr>
    <tr><td>textord_spacesize_ratiofp</td><td>2.8</td><td>Min ratio space/nonspace </td></tr>
    <tr><td>textord_spacesize_ratioprop</td><td>2</td><td>Min ratio space/nonspace </td></tr>
    <tr><td>textord_fpiqr_ratio</td><td>1.5</td><td>Pitch IQR/Gap IQR threshold </td></tr>
    <tr><td>textord_max_pitch_iqr</td><td>0.2</td><td>Xh fraction noise in pitch </td></tr>
    <tr><td>textord_fp_min_width</td><td>0.5</td><td>Min width of decent blobs </td></tr>
    <tr><td>textord_underline_offset</td><td>0.1</td><td>Fraction of x to ignore </td></tr>
    <tr><td>ambigs_debug_level</td><td>0</td><td>Debug level for unichar ambiguities </td></tr>
    <tr><td>classify_debug_level</td><td>0</td><td>Classify debug level </td></tr>
    <tr><td>classify_norm_method</td><td>1</td><td>Normalization Method ... </td></tr>
    <tr><td>matcher_debug_level</td><td>0</td><td>Matcher Debug Level </td></tr>
    <tr><td>matcher_debug_flags</td><td>0</td><td>Matcher Debug Flags </td></tr>
    <tr><td>classify_learning_debug_level</td><td>0</td><td>Learning Debug Level: </td></tr>
    <tr><td>matcher_permanent_classes_min</td><td>1</td><td>Min # of permanent classes </td></tr>
    <tr><td>matcher_min_examples_for_
    prototyping</td><td>3</td><td>Reliable Config Threshold </td></tr>
    <tr><td>matcher_sufficient_examples_
    for_prototyping</td><td>5</td><td>Enable adaption even if the ambiguities have not been seen </td></tr>
    <tr><td>classify_adapt_proto_threshold</td><td>230</td><td>Threshold for good protos during adaptive 0-255 </td></tr>
    <tr><td>classify_adapt_feature_threshold</td><td>230</td><td>Threshold for good features during adaptive 0-255 </td></tr>
    <tr><td>classify_class_pruner_threshold</td><td>229</td><td>Class Pruner Threshold 0-255 </td></tr>
    <tr><td>classify_class_pruner_multiplier</td><td>15</td><td>Class Pruner Multiplier 0-255: </td></tr>
    <tr><td>classify_cp_cutoff_strength</td><td>7</td><td>Class Pruner CutoffStrength: </td></tr>
    <tr><td>classify_integer_matcher_multiplier</td><td>10</td><td>Integer Matcher Multiplier 0-255: </td></tr>
    <tr><td>dawg_debug_level</td><td>0</td><td>Set to 1 for general debug info, to 2 for more details, to 3 to see all the debug messages </td></tr>
    <tr><td>hyphen_debug_level</td><td>0</td><td>Debug level for hyphenated words. </td></tr>
    <tr><td>stopper_smallword_size</td><td>2</td><td>Size of dict word to be treated as non-dict word </td></tr>
    <tr><td>stopper_debug_level</td><td>0</td><td>Stopper debug level </td></tr>
    <tr><td>tessedit_truncate_wordchoice_log</td><td>10</td><td>Max words to keep in list </td></tr>
    <tr><td>max_permuter_attempts</td><td>10000</td><td>Maximum number of different character choices to consider during permutation. This limit is especially useful when user patterns are specified, since overly generic patterns can result in dawg search exploring an overly large number of options. </td></tr>
    <tr><td>repair_unchopped_blobs</td><td>1</td><td>Fix blobs that aren't chopped </td></tr>
    <tr><td>chop_debug</td><td>0</td><td>Chop debug </td></tr>
    <tr><td>chop_split_length</td><td>10000</td><td>Split Length </td></tr>
    <tr><td>chop_same_distance</td><td>2</td><td>Same distance </td></tr>
    <tr><td>chop_min_outline_points</td><td>6</td><td>Min Number of Points on Outline </td></tr>
    <tr><td>chop_seam_pile_size</td><td>150</td><td>Max number of seams in seam_pile </td></tr>
    <tr><td>chop_inside_angle</td><td>-50</td><td>Min Inside Angle Bend </td></tr>
    <tr><td>chop_min_outline_area</td><td>2000</td><td>Min Outline Area </td></tr>
    <tr><td>chop_centered_maxwidth</td><td>90</td><td>Width of (smaller) chopped blobs above which we don't care that a chop is not near the center. </td></tr>
    <tr><td>chop_x_y_weight</td><td>3</td><td>X / Y length weight </td></tr>
    <tr><td>wordrec_debug_level</td><td>0</td><td>Debug level for wordrec </td></tr>
    <tr><td>wordrec_max_join_chunks</td><td>4</td><td>Max number of broken pieces to associate </td></tr>
    <tr><td>segsearch_debug_level</td><td>0</td><td>SegSearch debug level </td></tr>
    <tr><td>segsearch_max_pain_points</td><td>2000</td><td>Maximum number of pain points stored in the queue </td></tr>
    <tr><td>segsearch_max_futile_classifications</td><td>20</td><td>Maximum number of pain point classifications per chunk that did not result in finding a better word choice. </td></tr>
    <tr><td>language_model_debug_level</td><td>0</td><td>Language model debug level </td></tr>
    <tr><td>language_model_ngram_order</td><td>8</td><td>Maximum order of the character ngram model </td></tr>
    <tr><td>language_model_viterbi_list_
    max_num_prunable</td><td>10</td><td>Maximum number of prunable (those for which PrunablePath() is true) entries in each viterbi list recorded in BLOB_CHOICEs </td></tr>
    <tr><td>language_model_viterbi_list_max_size</td><td>500</td><td>Maximum size of viterbi lists recorded in BLOB_CHOICEs </td></tr>
    <tr><td>language_model_min_compound_length</td><td>3</td><td>Minimum length of compound words </td></tr>
    <tr><td>wordrec_display_segmentations</td><td>0</td><td>Display Segmentations </td></tr>
    <tr><td>tessedit_pageseg_mode</td><td>6</td><td>Page seg mode: 0=osd only, 1=auto+osd, 2=auto_only, 3=auto, 4=column, 5=block_vert, 6=block, 7=line, 8=word, 9=word_circle, 10=char,11=sparse_text, 12=sparse_text+osd, 13=raw_line (Values from PageSegMode enum in tesseract/publictypes.h) </td></tr>
    <tr><td>tessedit_ocr_engine_mode</td><td>2</td><td>Which OCR engine(s) to run (Tesseract, LSTM, both). Defaults to loading and running the most accurate available. </td></tr>
    <tr><td>pageseg_devanagari_split_strategy</td><td>0</td><td>Whether to use the top-line splitting process for Devanagari documents while performing page-segmentation. </td></tr>
    <tr><td>ocr_devanagari_split_strategy</td><td>0</td><td>Whether to use the top-line splitting process for Devanagari documents while performing ocr. </td></tr>
    <tr><td>bidi_debug</td><td>0</td><td>Debug level for BiDi </td></tr>
    <tr><td>applybox_debug</td><td>1</td><td>Debug level </td></tr>
    <tr><td>applybox_page</td><td>0</td><td>Page number to apply boxes from </td></tr>
    <tr><td>tessedit_bigram_debug</td><td>0</td><td>Amount of debug output for bigram correction. </td></tr>
    <tr><td>debug_noise_removal</td><td>0</td><td>Debug reassignment of small outlines </td></tr>
    <tr><td>noise_maxperblob</td><td>8</td><td>Max diacritics to apply to a blob </td></tr>
    <tr><td>noise_maxperword</td><td>16</td><td>Max diacritics to apply to a word </td></tr>
    <tr><td>debug_x_ht_level</td><td>0</td><td>Reestimate debug </td></tr>
    <tr><td>quality_min_initial_alphas_reqd</td><td>2</td><td>alphas in a good word </td></tr>
    <tr><td>tessedit_tess_adaption_mode</td><td>39</td><td>Adaptation decision algorithm for tess </td></tr>
    <tr><td>multilang_debug_level</td><td>0</td><td>Print multilang debug info. </td></tr>
    <tr><td>paragraph_debug_level</td><td>0</td><td>Print paragraph debug info. </td></tr>
    <tr><td>tessedit_preserve_min_wd_len</td><td>2</td><td>Only preserve wds longer than this </td></tr>
    <tr><td>crunch_rating_max</td><td>10</td><td>For adj length in rating per ch </td></tr>
    <tr><td>crunch_pot_indicators</td><td>1</td><td>How many potential indicators needed </td></tr>
    <tr><td>crunch_leave_lc_strings</td><td>4</td><td>Don't crunch words with long lower case strings </td></tr>
    <tr><td>crunch_leave_uc_strings</td><td>4</td><td>Don't crunch words with long lower case strings </td></tr>
    <tr><td>crunch_long_repetitions</td><td>3</td><td>Crunch words with long repetitions </td></tr>
    <tr><td>crunch_debug</td><td>0</td><td>As it says </td></tr>
    <tr><td>fixsp_non_noise_limit</td><td>1</td><td>How many non-noise blbs either side? </td></tr>
    <tr><td>fixsp_done_mode</td><td>1</td><td>What constitues done for spacing </td></tr>
    <tr><td>debug_fix_space_level</td><td>0</td><td>Contextual fixspace debug </td></tr>
    <tr><td>x_ht_acceptance_tolerance</td><td>8</td><td>Max allowed deviation of blob top outside of font data </td></tr>
    <tr><td>x_ht_min_change</td><td>8</td><td>Min change in xht before actually trying it </td></tr>
    <tr><td>superscript_debug</td><td>0</td><td>Debug level for sub & superscript fixer </td></tr>
    <tr><td>jpg_quality</td><td>85</td><td>Set JPEG quality level </td></tr>
    <tr><td>user_defined_dpi</td><td>0</td><td>Specify DPI for input image </td></tr>
    <tr><td>min_characters_to_try</td><td>50</td><td>Specify minimum characters to try during OSD </td></tr>
    <tr><td>suspect_level</td><td>99</td><td>Suspect marker level </td></tr>
    <tr><td>suspect_short_words</td><td>2</td><td>Don't suspect dict wds longer than this </td></tr>
    <tr><td>tessedit_reject_mode</td><td>0</td><td>Rejection algorithm </td></tr>
    <tr><td>tessedit_image_border</td><td>2</td><td>Rej blbs near image edge limit </td></tr>
    <tr><td>min_sane_x_ht_pixels</td><td>8</td><td>Reject any x-ht lt or eq than this </td></tr>
    <tr><td>tessedit_page_number</td><td>-1</td><td>-1 -> All pages, else specific page to process </td></tr>
    <tr><td>tessedit_parallelize</td><td>1</td><td>Run in parallel where possible </td></tr>
    <tr><td>lstm_choice_mode</td><td>2</td><td>Allows to include alternative symbols choices in the hOCR output. Valid input values are 0, 1 and 2. 0 is the default value. With 1 the alternative symbol choices per timestep are included. With 2 alternative symbol choices are extracted from the CTC process instead of the lattice. The choices are mapped per character. </td></tr>
    <tr><td>lstm_choice_iterations</td><td>5</td><td>Sets the number of cascading iterations for the Beamsearch in lstm_choice_mode. Note that lstm_choice_mode must be set to a value greater than 0 to produce results. </td></tr>
    <tr><td>tosp_debug_level</td><td>0</td><td>Debug data </td></tr>
    <tr><td>tosp_enough_space_samples_for_median</td><td>3</td><td>or should we use mean </td></tr>
    <tr><td>tosp_redo_kern_limit</td><td>10</td><td>No.samples reqd to reestimate for row </td></tr>
    <tr><td>tosp_few_samples</td><td>40</td><td>No.gaps reqd with 1 large gap to treat as a table </td></tr>
    <tr><td>tosp_short_row</td><td>20</td><td>No.gaps reqd with few cert spaces to use certs </td></tr>
    <tr><td>tosp_sanity_method</td><td>1</td><td>How to avoid being silly </td></tr>
    <tr><td>textord_max_noise_size</td><td>7</td><td>Pixel size of noise </td></tr>
    <tr><td>textord_baseline_debug</td><td>0</td><td>Baseline debug level </td></tr>
    <tr><td>textord_noise_sizefraction</td><td>10</td><td>Fraction of size for maxima </td></tr>
    <tr><td>textord_noise_translimit</td><td>16</td><td>Transitions for normal blob </td></tr>
    <tr><td>textord_noise_sncount</td><td>1</td><td>super norm blobs to save row </td></tr>
    <tr><td>use_ambigs_for_adaption</td><td>0</td><td>Use ambigs for deciding whether to adapt to a character </td></tr>
    <tr><td>allow_blob_division</td><td>1</td><td>Use divisible blobs chopping </td></tr>
    <tr><td>prioritize_division</td><td>0</td><td>Prioritize blob division over chopping </td></tr>
    <tr><td>classify_enable_learning</td><td>1</td><td>Enable adaptive classifier </td></tr>
    <tr><td>tess_cn_matching</td><td>0</td><td>Character Normalized Matching </td></tr>
    <tr><td>tess_bn_matching</td><td>0</td><td>Baseline Normalized Matching </td></tr>
    <tr><td>classify_enable_adaptive_matcher</td><td>1</td><td>Enable adaptive classifier </td></tr>
    <tr><td>classify_use_pre_adapted_templates</td><td>0</td><td>Use pre-adapted classifier templates </td></tr>
    <tr><td>classify_save_adapted_templates</td><td>0</td><td>Save adapted templates to a file </td></tr>
    <tr><td>classify_enable_adaptive_debugger</td><td>0</td><td>Enable match debugger </td></tr>
    <tr><td>classify_nonlinear_norm</td><td>0</td><td>Non-linear stroke-density normalization </td></tr>
    <tr><td>disable_character_fragments</td><td>1</td><td>Do not include character fragments in the results of the classifier </td></tr>
    <tr><td>classify_debug_character_fragments</td><td>0</td><td>Bring up graphical debugging windows for fragments training </td></tr>
    <tr><td>matcher_debug_separate_windows</td><td>0</td><td>Use two different windows for debugging the matching: One for the protos and one for the features. </td></tr>
    <tr><td>classify_bln_numeric_mode</td><td>0</td><td>Assume the input is numbers [0-9]. </td></tr>
    <tr><td>load_system_dawg</td><td>1</td><td>Load system word dawg. </td></tr>
    <tr><td>load_freq_dawg</td><td>1</td><td>Load frequent word dawg. </td></tr>
    <tr><td>load_unambig_dawg</td><td>1</td><td>Load unambiguous word dawg. </td></tr>
    <tr><td>load_punc_dawg</td><td>1</td><td>Load dawg with punctuation patterns. </td></tr>
    <tr><td>load_number_dawg</td><td>1</td><td>Load dawg with number patterns. </td></tr>
    <tr><td>load_bigram_dawg</td><td>1</td><td>Load dawg with special word bigrams. </td></tr>
    <tr><td>use_only_first_uft8_step</td><td>0</td><td>Use only the first UTF8 step of the given string when computing log probabilities. </td></tr>
    <tr><td>stopper_no_acceptable_choices</td><td>0</td><td>Make AcceptableChoice() always return false. Useful when there is a need to explore all segmentations </td></tr>
    <tr><td>segment_nonalphabetic_script</td><td>0</td><td>Don't use any alphabetic-specific tricks. Set to true in the traineddata config file for scripts that are cursive or inherently fixed-pitch </td></tr>
    <tr><td>save_doc_words</td><td>0</td><td>Save Document Words </td></tr>
    <tr><td>merge_fragments_in_matrix</td><td>1</td><td>Merge the fragments in the ratings matrix and delete them after merging </td></tr>
    <tr><td>wordrec_enable_assoc</td><td>1</td><td>Associator Enable </td></tr>
    <tr><td>force_word_assoc</td><td>0</td><td>force associator to run regardless of what enable_assoc is. This is used for CJK where component grouping is necessary. </td></tr>
    <tr><td>chop_enable</td><td>1</td><td>Chop enable </td></tr>
    <tr><td>chop_vertical_creep</td><td>0</td><td>Vertical creep </td></tr>
    <tr><td>chop_new_seam_pile</td><td>1</td><td>Use new seam_pile </td></tr>
    <tr><td>assume_fixed_pitch_char_segment</td><td>0</td><td>include fixed-pitch heuristics in char segmentation </td></tr>
    <tr><td>wordrec_skip_no_truth_words</td><td>0</td><td>Only run OCR for words that had truth recorded in BlamerBundle </td></tr>
    <tr><td>wordrec_debug_blamer</td><td>0</td><td>Print blamer debug messages </td></tr>
    <tr><td>wordrec_run_blamer</td><td>0</td><td>Try to set the blame for errors </td></tr>
    <tr><td>save_alt_choices</td><td>1</td><td>Save alternative paths found during chopping and segmentation search </td></tr>
    <tr><td>language_model_ngram_on</td><td>0</td><td>Turn on/off the use of character ngram model </td></tr>
    <tr><td>language_model_ngram_use_
    only_first_uft8_step</td><td>0</td><td>Use only the first UTF8 step of the given string when computing log probabilities. </td></tr>
    <tr><td>language_model_ngram_space_
    delimited_language</td><td>1</td><td>Words are delimited by space </td></tr>
    <tr><td>language_model_use_sigmoidal_certainty</td><td>0</td><td>Use sigmoidal score for certainty </td></tr>
    <tr><td>tessedit_resegment_from_boxes</td><td>0</td><td>Take segmentation and labeling from box file </td></tr>
    <tr><td>tessedit_resegment_from_line_boxes</td><td>0</td><td>Conversion of word/line box file to char box file </td></tr>
    <tr><td>tessedit_train_from_boxes</td><td>0</td><td>Generate training data from boxed chars </td></tr>
    <tr><td>tessedit_make_boxes_from_boxes</td><td>0</td><td>Generate more boxes from boxed chars </td></tr>
    <tr><td>tessedit_train_line_recognizer</td><td>0</td><td>Break input into lines and remap boxes if present </td></tr>
    <tr><td>tessedit_dump_pageseg_images</td><td>0</td><td>Dump intermediate images made during page segmentation </td></tr>
    <tr><td>tessedit_do_invert</td><td>1</td><td>Try inverting the image in `LSTMRecognizeWord` </td></tr>
    <tr><td>tessedit_ambigs_training</td><td>0</td><td>Perform training for ambiguities </td></tr>
    <tr><td>tessedit_adaption_debug</td><td>0</td><td>Generate and print debug information for adaption </td></tr>
    <tr><td>applybox_learn_chars_and_char_frags_mode</td><td>0</td><td>Learn both character fragments (as is done in the special low exposure mode) as well as unfragmented characters. </td></tr>
    <tr><td>applybox_learn_ngrams_mode</td><td>0</td><td>Each bounding box is assumed to contain ngrams. Only learn the ngrams whose outlines overlap horizontally. </td></tr>
    <tr><td>tessedit_display_outwords</td><td>0</td><td>Draw output words </td></tr>
    <tr><td>tessedit_dump_choices</td><td>0</td><td>Dump char choices </td></tr>
    <tr><td>tessedit_timing_debug</td><td>0</td><td>Print timing stats </td></tr>
    <tr><td>tessedit_fix_fuzzy_spaces</td><td>1</td><td>Try to improve fuzzy spaces </td></tr>
    <tr><td>tessedit_unrej_any_wd</td><td>0</td><td>Don't bother with word plausibility </td></tr>
    <tr><td>tessedit_fix_hyphens</td><td>1</td><td>Crunch double hyphens? </td></tr>
    <tr><td>tessedit_enable_doc_dict</td><td>1</td><td>Add words to the document dictionary </td></tr>
    <tr><td>tessedit_debug_fonts</td><td>0</td><td>Output font info per char </td></tr>
    <tr><td>tessedit_debug_block_rejection</td><td>0</td><td>Block and Row stats </td></tr>
    <tr><td>tessedit_enable_bigram_correction</td><td>1</td><td>Enable correction based on the word bigram dictionary. </td></tr>
    <tr><td>tessedit_enable_dict_correction</td><td>0</td><td>Enable single word correction based on the dictionary. </td></tr>
    <tr><td>enable_noise_removal</td><td>1</td><td>Remove and conditionally reassign small outlines when they confuse layout analysis, determining diacritics vs noise </td></tr>
    <tr><td>tessedit_minimal_rej_pass1</td><td>0</td><td>Do minimal rejection on pass 1 output </td></tr>
    <tr><td>tessedit_test_adaption</td><td>0</td><td>Test adaption criteria </td></tr>
    <tr><td>test_pt</td><td>0</td><td>Test for point </td></tr>
    <tr><td>paragraph_text_based</td><td>1</td><td>Run paragraph detection on the post-text-recognition (more accurate) </td></tr>
    <tr><td>lstm_use_matrix</td><td>1</td><td>Use ratings matrix/beam search with lstm </td></tr>
    <tr><td>tessedit_good_quality_unrej</td><td>1</td><td>Reduce rejection on good docs </td></tr>
    <tr><td>tessedit_use_reject_spaces</td><td>1</td><td>Reject spaces? </td></tr>
    <tr><td>tessedit_preserve_blk_rej_perfect_wds</td><td>1</td><td>Only rej partially rejected words in block rejection </td></tr>
    <tr><td>tessedit_preserve_row_rej_perfect_wds</td><td>1</td><td>Only rej partially rejected words in row rejection </td></tr>
    <tr><td>tessedit_dont_blkrej_good_wds</td><td>0</td><td>Use word segmentation quality metric </td></tr>
    <tr><td>tessedit_dont_rowrej_good_wds</td><td>0</td><td>Use word segmentation quality metric </td></tr>
    <tr><td>tessedit_row_rej_good_docs</td><td>1</td><td>Apply row rejection to good docs </td></tr>
    <tr><td>tessedit_reject_bad_qual_wds</td><td>1</td><td>Reject all bad quality wds </td></tr>
    <tr><td>tessedit_debug_doc_rejection</td><td>0</td><td>Page stats </td></tr>
    <tr><td>tessedit_debug_quality_metrics</td><td>0</td><td>Output data to debug file </td></tr>
    <tr><td>bland_unrej</td><td>0</td><td>unrej potential with no checks </td></tr>
    <tr><td>unlv_tilde_crunching</td><td>0</td><td>Mark v.bad words for tilde crunch </td></tr>
    <tr><td>hocr_font_info</td><td>0</td><td>Add font info to hocr output </td></tr>
    <tr><td>hocr_char_boxes</td><td>0</td><td>Add coordinates for each character to hocr output </td></tr>
    <tr><td>crunch_early_merge_tess_fails</td><td>1</td><td>Before word crunch? </td></tr>
    <tr><td>crunch_early_convert_bad_unlv_chs</td><td>0</td><td>Take out ~^ early? </td></tr>
    <tr><td>crunch_terrible_garbage</td><td>1</td><td>As it says </td></tr>
    <tr><td>crunch_leave_ok_strings</td><td>1</td><td>Don't touch sensible strings </td></tr>
    <tr><td>crunch_accept_ok</td><td>1</td><td>Use acceptability in okstring </td></tr>
    <tr><td>crunch_leave_accept_strings</td><td>0</td><td>Don't pot crunch sensible strings </td></tr>
    <tr><td>crunch_include_numerals</td><td>0</td><td>Fiddle alpha figures </td></tr>
    <tr><td>tessedit_prefer_joined_punct</td><td>0</td><td>Reward punctuation joins </td></tr>
    <tr><td>tessedit_write_block_separators</td><td>0</td><td>Write block separators in output </td></tr>
    <tr><td>tessedit_write_rep_codes</td><td>0</td><td>Write repetition char code </td></tr>
    <tr><td>tessedit_write_unlv</td><td>0</td><td>Write .unlv output file </td></tr>
    <tr><td>tessedit_create_txt</td><td>0</td><td>Write .txt output file </td></tr>
    <tr><td>tessedit_create_hocr</td><td>0</td><td>Write .html hOCR output file </td></tr>
    <tr><td>tessedit_create_alto</td><td>0</td><td>Write .xml ALTO file </td></tr>
    <tr><td>tessedit_create_lstmbox</td><td>0</td><td>Write .box file for LSTM training </td></tr>
    <tr><td>tessedit_create_tsv</td><td>0</td><td>Write .tsv output file </td></tr>
    <tr><td>tessedit_create_wordstrbox</td><td>0</td><td>Write WordStr format .box output file </td></tr>
    <tr><td>tessedit_create_pdf</td><td>0</td><td>Write .pdf output file </td></tr>
    <tr><td>textonly_pdf</td><td>0</td><td>Create PDF with only one invisible text layer </td></tr>
    <tr><td>suspect_constrain_1Il</td><td>0</td><td>UNLV keep 1Il chars rejected </td></tr>
    <tr><td>tessedit_minimal_rejection</td><td>0</td><td>Only reject tess failures </td></tr>
    <tr><td>tessedit_zero_rejection</td><td>0</td><td>Don't reject ANYTHING </td></tr>
    <tr><td>tessedit_word_for_word</td><td>0</td><td>Make output have exactly one word per WERD </td></tr>
    <tr><td>tessedit_zero_kelvin_rejection</td><td>0</td><td>Don't reject ANYTHING AT ALL </td></tr>
    <tr><td>tessedit_rejection_debug</td><td>0</td><td>Adaption debug </td></tr>
    <tr><td>tessedit_flip_0O</td><td>1</td><td>Contextual 0O O0 flips </td></tr>
    <tr><td>rej_trust_doc_dawg</td><td>0</td><td>Use DOC dawg in 11l conf. detector </td></tr>
    <tr><td>rej_1Il_use_dict_word</td><td>0</td><td>Use dictword test </td></tr>
    <tr><td>rej_1Il_trust_permuter_type</td><td>1</td><td>Don't double check </td></tr>
    <tr><td>rej_use_tess_accepted</td><td>1</td><td>Individual rejection control </td></tr>
    <tr><td>rej_use_tess_blanks</td><td>1</td><td>Individual rejection control </td></tr>
    <tr><td>rej_use_good_perm</td><td>1</td><td>Individual rejection control </td></tr>
    <tr><td>rej_use_sensible_wd</td><td>0</td><td>Extend permuter check </td></tr>
    <tr><td>rej_alphas_in_number_perm</td><td>0</td><td>Extend permuter check </td></tr>
    <tr><td>tessedit_create_boxfile</td><td>0</td><td>Output text with boxes </td></tr>
    <tr><td>tessedit_write_images</td><td>0</td><td>Capture the image from the IPE </td></tr>
    <tr><td>interactive_display_mode</td><td>0</td><td>Run interactively? </td></tr>
    <tr><td>tessedit_override_permuter</td><td>1</td><td>According to dict_word </td></tr>
    <tr><td>tessedit_use_primary_params_model</td><td>0</td><td>In multilingual mode use params model of the primary language </td></tr>
    <tr><td>textord_tabfind_show_vlines</td><td>0</td><td>Debug line finding </td></tr>
    <tr><td>textord_use_cjk_fp_model</td><td>0</td><td>Use CJK fixed pitch model </td></tr>
    <tr><td>poly_allow_detailed_fx</td><td>0</td><td>Allow feature extractors to see the original outline </td></tr>
    <tr><td>tessedit_init_config_only</td><td>0</td><td>Only initialize with the config file. Useful if the instance is not going to be used for OCR but say only for layout analysis. </td></tr>
    <tr><td>textord_equation_detect</td><td>0</td><td>Turn on equation detector </td></tr>
    <tr><td>textord_tabfind_vertical_text</td><td>1</td><td>Enable vertical detection </td></tr>
    <tr><td>textord_tabfind_force_vertical_text</td><td>0</td><td>Force using vertical text page mode </td></tr>
    <tr><td>preserve_interword_spaces</td><td>0</td><td>Preserve multiple interword spaces </td></tr>
    <tr><td>pageseg_apply_music_mask</td><td>1</td><td>Detect music staff and remove intersecting components </td></tr>
    <tr><td>textord_single_height_mode</td><td>0</td><td>Script has no xheight, so use a single mode </td></tr>
    <tr><td>tosp_old_to_method</td><td>0</td><td>Space stats use prechopping? </td></tr>
    <tr><td>tosp_old_to_constrain_sp_kn</td><td>0</td><td>Constrain relative values of inter and intra-word gaps for old_to_method. </td></tr>
    <tr><td>tosp_only_use_prop_rows</td><td>1</td><td>Block stats to use fixed pitch rows? </td></tr>
    <tr><td>tosp_force_wordbreak_on_punct</td><td>0</td><td>Force word breaks on punct to break long lines in non-space delimited langs </td></tr>
    <tr><td>tosp_use_pre_chopping</td><td>0</td><td>Space stats use prechopping? </td></tr>
    <tr><td>tosp_old_to_bug_fix</td><td>0</td><td>Fix suspected bug in old code </td></tr>
    <tr><td>tosp_block_use_cert_spaces</td><td>1</td><td>Only stat OBVIOUS spaces </td></tr>
    <tr><td>tosp_row_use_cert_spaces</td><td>1</td><td>Only stat OBVIOUS spaces </td></tr>
    <tr><td>tosp_narrow_blobs_not_cert</td><td>1</td><td>Only stat OBVIOUS spaces </td></tr>
    <tr><td>tosp_row_use_cert_spaces1</td><td>1</td><td>Only stat OBVIOUS spaces </td></tr>
    <tr><td>tosp_recovery_isolated_row_stats</td><td>1</td><td>Use row alone when inadequate cert spaces </td></tr>
    <tr><td>tosp_only_small_gaps_for_kern</td><td>0</td><td>Better guess </td></tr>
    <tr><td>tosp_all_flips_fuzzy</td><td>0</td><td>Pass ANY flip to context? </td></tr>
    <tr><td>tosp_fuzzy_limit_all</td><td>1</td><td>Don't restrict kn->sp fuzzy limit to tables </td></tr>
    <tr><td>tosp_stats_use_xht_gaps</td><td>1</td><td>Use within xht gap for wd breaks </td></tr>
    <tr><td>tosp_use_xht_gaps</td><td>1</td><td>Use within xht gap for wd breaks </td></tr>
    <tr><td>tosp_only_use_xht_gaps</td><td>0</td><td>Only use within xht gap for wd breaks </td></tr>
    <tr><td>tosp_rule_9_test_punct</td><td>0</td><td>Don't chng kn to space next to punct </td></tr>
    <tr><td>tosp_flip_fuzz_kn_to_sp</td><td>1</td><td>Default flip </td></tr>
    <tr><td>tosp_flip_fuzz_sp_to_kn</td><td>1</td><td>Default flip </td></tr>
    <tr><td>tosp_improve_thresh</td><td>0</td><td>Enable improvement heuristic </td></tr>
    <tr><td>textord_no_rejects</td><td>0</td><td>Don't remove noise blobs </td></tr>
    <tr><td>textord_show_blobs</td><td>0</td><td>Display unsorted blobs </td></tr>
    <tr><td>textord_show_boxes</td><td>0</td><td>Display unsorted blobs </td></tr>
    <tr><td>textord_noise_rejwords</td><td>1</td><td>Reject noise-like words </td></tr>
    <tr><td>textord_noise_rejrows</td><td>1</td><td>Reject noise-like rows </td></tr>
    <tr><td>textord_noise_debug</td><td>0</td><td>Debug row garbage detector </td></tr>
    <tr><td>classify_learn_debug_str</td><td></td><td>Class str to debug learning </td></tr>
    <tr><td>user_words_file</td><td></td><td>A filename of user-provided words. </td></tr>
    <tr><td>user_words_suffix</td><td></td><td>A suffix of user-provided words located in tessdata. </td></tr>
    <tr><td>user_patterns_file</td><td></td><td>A filename of user-provided patterns. </td></tr>
    <tr><td>user_patterns_suffix</td><td></td><td>A suffix of user-provided patterns located in tessdata. </td></tr>
    <tr><td>output_ambig_words_file</td><td></td><td>Output file for ambiguities found in the dictionary </td></tr>
    <tr><td>word_to_debug</td><td></td><td>Word for which stopper debug information should be printed to stdout </td></tr>
    <tr><td>tessedit_char_blacklist</td><td></td><td>Blacklist of chars not to recognize </td></tr>
    <tr><td>tessedit_char_whitelist</td><td></td><td>Whitelist of chars to recognize </td></tr>
    <tr><td>tessedit_char_unblacklist</td><td></td><td>List of chars to override tessedit_char_blacklist </td></tr>
    <tr><td>tessedit_write_params_to_file</td><td></td><td>Write all parameters to the given file. </td></tr>
    <tr><td>applybox_exposure_pattern</td><td>.exp</td><td>Exposure value follows this pattern in the image filename. The name of the image files are expected to be in the form [lang].[fontname].exp [num].tif </td></tr>
    <tr><td>chs_leading_punct('`"</td><td>Leading punctuation</td><td></td></tr>
    <tr><td>chs_trailing_punct1</td><td>).,;:?!</td><td>1st Trailing punctuation </td></tr>
    <tr><td>chs_trailing_punct2)'`"</td><td>2nd Trailing punctuation</td><td></td></tr>
    <tr><td>outlines_odd</td><td>%</td><td>Non standard number of outlines </td></tr>
    <tr><td>outlines_2ij!?%":;</td><td>Non standard number of outlines</td><td></td></tr>
    <tr><td>numeric_punctuation</td><td>.,</td><td>Punct. chs expected WITHIN numbers </td></tr>
    <tr><td>unrecognised_char</td><td></td><td>Output char for unidentified blobs </td></tr>
    <tr><td>ok_repeated_ch_non_alphanum_wds</td><td>-?*=</td><td>Allow NN to unrej </td></tr>
    <tr><td>conflict_set_I_l_1</td><td>Il1 []</td><td>Il1 conflict set </td></tr>
    <tr><td>file_type</td><td>.tif</td><td>Filename extension </td></tr>
    <tr><td>tessedit_load_sublangs</td><td></td><td>List of languages to load with this one </td></tr>
    <tr><td>page_separator</td><td></td><td>Page separator (default is form feed control character) </td></tr>
    <tr><td>classify_char_norm_range</td><td>0.2</td><td>Character Normalization Range ... </td></tr>
    <tr><td>classify_max_rating_ratio</td><td>1.5</td><td>Veto ratio between classifier ratings </td></tr>
    <tr><td>classify_max_certainty_margin</td><td>5.5</td><td>Veto difference between classifier certainties </td></tr>
    <tr><td>matcher_good_threshold</td><td>0.125</td><td>Good Match (0-1) </td></tr>
    <tr><td>matcher_reliable_adaptive_result</td><td>0</td><td>Great Match (0-1) </td></tr>
    <tr><td>matcher_perfect_threshold</td><td>0.02</td><td>Perfect Match (0-1) </td></tr>
    <tr><td>matcher_bad_match_pad</td><td>0.15</td><td>Bad Match Pad (0-1) </td></tr>
    <tr><td>matcher_rating_margin</td><td>0.1</td><td>New template margin (0-1) </td></tr>
    <tr><td>matcher_avg_noise_size</td><td>12</td><td>Avg. noise blob length </td></tr>
    <tr><td>matcher_clustering_max_angle_delta</td><td>0.015</td><td>Maximum angle delta for prototype clustering </td></tr>
    <tr><td>classify_misfit_junk_penalty</td><td>0</td><td>Penalty to apply when a non-alnum is vertically out of its expected textline position </td></tr>
    <tr><td>rating_scale</td><td>1.5</td><td>Rating scaling factor </td></tr>
    <tr><td>certainty_scale</td><td>20</td><td>Certainty scaling factor </td></tr>
    <tr><td>tessedit_class_miss_scale</td><td>0.00390625</td><td>Scale factor for features not used </td></tr>
    <tr><td>classify_adapted_pruning_factor</td><td>2.5</td><td>Prune poor adapted results this much worse than best result </td></tr>
    <tr><td>classify_adapted_pruning_threshold</td><td>-1</td><td>Threshold at which classify_adapted_pruning_factor starts </td></tr>
    <tr><td>classify_character_fragments_
    garbage_certainty_threshold</td><td>-3</td><td>Exclude fragments that do not look like whole characters from training and adaption </td></tr>
    <tr><td>speckle_large_max_size</td><td>0.3</td><td>Max large speckle size </td></tr>
    <tr><td>speckle_rating_penalty</td><td>10</td><td>Penalty to add to worst rating for noise </td></tr>
    <tr><td>xheight_penalty_subscripts</td><td>0.125</td><td>Score penalty (0.1 = 10%) added if there are subscripts or superscripts in a word, but it is otherwise OK. </td></tr>
    <tr><td>xheight_penalty_inconsistent</td><td>0.25</td><td>Score penalty (0.1 = 10%) added if an xheight is inconsistent. </td></tr>
    <tr><td>segment_penalty_dict_frequent_word</td><td>1</td><td>Score multiplier for word matches which have good case and are frequent in the given language (lower is better). </td></tr>
    <tr><td>segment_penalty_dict_case_ok</td><td>1.1</td><td>Score multiplier for word matches that have good case (lower is better). </td></tr>
    <tr><td>segment_penalty_dict_case_bad</td><td>1.3125</td><td>Default score multiplier for word matches, which may have case issues (lower is better). </td></tr>
    <tr><td>segment_penalty_dict_nonword</td><td>1.25</td><td>Score multiplier for glyph fragment segmentations which do not match a dictionary word (lower is better). </td></tr>
    <tr><td>segment_penalty_garbage</td><td>1.5</td><td>Score multiplier for poorly cased strings that are not in the dictionary and generally look like garbage (lower is better). </td></tr>
    <tr><td>certainty_scale</td><td>20</td><td>Certainty scaling factor </td></tr>
    <tr><td>stopper_nondict_certainty_base</td><td>-2.5</td><td>Certainty threshold for non-dict words </td></tr>
    <tr><td>stopper_phase2_certainty_rejection_offset</td><td>1</td><td>Reject certainty offset </td></tr>
    <tr><td>stopper_certainty_per_char</td><td>-0.5</td><td>Certainty to add for each dict char above small word size. </td></tr>
    <tr><td>stopper_allowable_character_badness</td><td>3</td><td>Max certaintly variation allowed in a word (in sigma) </td></tr>
    <tr><td>doc_dict_pending_threshold</td><td>0</td><td>Worst certainty for using pending dictionary </td></tr>
    <tr><td>doc_dict_certainty_threshold</td><td>-2.25</td><td>Worst certainty for words that can be inserted into the document dictionary </td></tr>
    <tr><td>tessedit_certainty_threshold</td><td>-2.25</td><td>Good blob limit </td></tr>
    <tr><td>chop_split_dist_knob</td><td>0.5</td><td>Split length adjustment </td></tr>
    <tr><td>chop_overlap_knob</td><td>0.9</td><td>Split overlap adjustment </td></tr>
    <tr><td>chop_center_knob</td><td>0.15</td><td>Split center adjustment </td></tr>
    <tr><td>chop_sharpness_knob</td><td>0.06</td><td>Split sharpness adjustment </td></tr>
    <tr><td>chop_width_change_knob</td><td>5</td><td>Width change adjustment </td></tr>
    <tr><td>chop_ok_split</td><td>100</td><td>OK split limit </td></tr>
    <tr><td>chop_good_split</td><td>50</td><td>Good split limit </td></tr>
    <tr><td>segsearch_max_char_wh_ratio</td><td>2</td><td>Maximum character width-to-height ratio</td></tr>
</table>

